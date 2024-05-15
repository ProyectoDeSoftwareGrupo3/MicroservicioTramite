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

        public async Task<List<TramiteTipo>> GetAllTramiteTipo()
        {
            try
            {
                return await _context.TramiteTipos.ToListAsync();
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }

        public async Task<TramiteTipo> GetTramiteTipoById(int id)
        {
            try
            {
                return await _context.TramiteTipos.FirstAsync(t => t.Id == id);
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }
    }
}
