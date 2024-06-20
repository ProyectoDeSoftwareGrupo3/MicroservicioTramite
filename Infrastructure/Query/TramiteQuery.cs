using Application.Exceptions;
using Application.Interfaces.ITramite;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Infrastructure.Query
{
    public class TramiteQuery : ITramiteQuery
    {
        private readonly TramiteDbContext _context;
        public TramiteQuery(TramiteDbContext context)
        {
            _context = context;
        }

        public async Task<CabeceraTramite> GetTramiteById(int id)
        {
            try
            {
                return await _context.CabeceraTramites
                    .Include(ct => ct.TramiteTransito)
                    .Include(ct => ct.TramiteAdopcion)
                    .Include(ct => ct.Estado)
                    .FirstOrDefaultAsync(t => t.Id == id);

            }
            catch (DbException)
            {
                throw new Conflict("Hubo un error en la base de datos");
            }
        }
        public async Task<CabeceraTramite> GetTramiteByAnimalId(int id)
        {
            try
            {
                return await _context.CabeceraTramites
                    .Include(t => t.TramiteTransito)
                    .Include(t => t.TramiteAdopcion)
                    .Include(ct => ct.Estado)
                    .FirstOrDefaultAsync(t => t.AnimalId == id);

            }
            catch (DbException)
            {
                throw new Conflict("Hubo un error en la base de datos");
            }
        }

        public async Task<List<CabeceraTramite>> GetTramitesFilters(int? tramiteEstado, int? animalId)
        {
            try
            {
                if (tramiteEstado == null && animalId == null)
                {
                    return await _context.CabeceraTramites
                        .Include(ct => ct.Estado)
                        .Include(t => t.TramiteTransito)
                        .Include(t => t.TramiteAdopcion)
                        .ToListAsync();
                }
                if (tramiteEstado == null)
                {
                    return await _context.CabeceraTramites
                        .Where(t => t.AnimalId == animalId)
                        .Include(t => t.Estado)
                        .Include(t => t.TramiteTransito)
                        .Include(t => t.TramiteAdopcion)
                        .ToListAsync();
                }

                return await _context.CabeceraTramites
                        .Where(t => t.EstadoId == tramiteEstado)
                        .Include(t => t.Estado)
                        .Include(t => t.TramiteTransito)
                        .Include(t => t.TramiteAdopcion)
                        .ToListAsync();
            }
            catch (DbException)
            {
                throw new Conflict("Hubo un error en la base de datos");
            }
        }

        public async Task<List<CabeceraTramiteDto>> GetTramites()
        {
            try
            {
                var tramite = await _context.CabeceraTramites
                    .Include(t => t.Estado)
                    .Include(t => t.TramiteTransito)
                    .Include(t => t.TramiteAdopcion)
                    .ToListAsync();

                var tramiteDtos = tramite.Select(tramite => new CabeceraTramiteDto(tramite)).ToList();

                return tramiteDtos;
            }
            catch (DbException)
            {
                throw new Conflict("Hubo un error en la base de datos");
            }
        }

     
        public async Task<IEnumerable<CabeceraTramite>> GetAllAsync()
        {
            return await _context.CabeceraTramites.ToListAsync();
        }
    }
}
