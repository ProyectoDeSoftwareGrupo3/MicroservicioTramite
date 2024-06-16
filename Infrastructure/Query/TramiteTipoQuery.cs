using Application.Exceptions;
using Application.Interfaces.ITramiteTipo;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class TramiteTipoQuery : ITramiteTipoQuery
    {
        private readonly TramiteDbContext _context;
        public TramiteTipoQuery(TramiteDbContext context)
        {
            _context = context;
        }

        public async Task<List<TramiteAdopcion>> GetAllTramiteAdopcion()
        {
            try
            {
                return await _context.TramiteAdopciones
                    .Include(ta => ta.CabeceraTramite)
                    .ToListAsync();
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }

        public async Task<TramiteAdopcion> GetTramiteAdopcionById(Guid id)
        {
            try
            {
                return await _context.TramiteAdopciones
                    .Include(ta => ta.CabeceraTramite)
                    .FirstAsync(t => t.TramiteId == id);
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }

        public async Task<List<TramiteTransito>> GetAllTramiteTransito()
        {
            try
            {
                return await _context.TramiteTransitos
                    .Include(ta => ta.CabeceraTramite)
                    .ToListAsync();
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }

        public async Task<TramiteTransito> GetTramiteTransitoById(Guid id)
        {
            try
            {
                return await _context.TramiteTransitos
                    .Include(ta => ta.CabeceraTramite)
                    .FirstAsync(t => t.TramiteId == id);
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }
    }
}
