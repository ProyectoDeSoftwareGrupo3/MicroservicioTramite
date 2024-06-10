using Application.Exceptions;
using Application.Interfaces.ITramite;
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

        public async Task<Tramite> GetTramiteById(int id)
        {
            try
            {
                return await _context.Tramites
                    .Include(t => t.TramiteEstado)
                    .Include(t => t.TramiteTipo)
                    .FirstOrDefaultAsync(t => t.Id == id);

            }
            catch (DbException)
            {
                throw new Conflict("Hubo un error en la base de datos");
            }
        }
        public async Task<Tramite> GetTramiteByAnimalId(int id)
        {
            try
            {
                return await _context.Tramites
                    .Include(t => t.TramiteEstado)
                    .Include(t => t.TramiteTipo)
                    .FirstOrDefaultAsync(t => t.AnimalId == id);

            }
            catch (DbException)
            {
                throw new Conflict("Hubo un error en la base de datos");
            }
        }

        public async Task<List<Tramite>>GetTramitesByEstado(int? tramiteEstado)
        {
            try
            {
                if (tramiteEstado == null)
                {
                    return await _context.Tramites
                        .Include(t => t.TramiteEstado)
                        .Include(t => t.TramiteTipo)
                        .ToListAsync();
                }

                return await _context.Tramites
                        .Where(t => t.TramiteEstadoId == tramiteEstado)
                        .Include(t => t.TramiteEstado)
                        .Include(t => t.TramiteTipo)
                        .ToListAsync();
            }
            catch (DbException)
            {
                throw new Conflict("Hubo un error en la base de datos");
            }
        }

        public async Task<List<Tramite>> GetTramites()
        {
            try
            {
                return await _context.Tramites.ToListAsync();
            }
            catch (DbException)
            {
                throw new Conflict("Hubo un error en la base de datos");
            }
        }
    }
}
