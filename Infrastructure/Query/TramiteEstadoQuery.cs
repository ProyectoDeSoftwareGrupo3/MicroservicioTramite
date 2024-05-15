using Application.Exceptions;
using Application.Interfaces.ITramiteEstado;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class TramiteEstadoQuery : ITramiteEstadoQuery
    {
        private readonly TramiteDbContext _context;
        public TramiteEstadoQuery(TramiteDbContext context)
        {
            _context = context;
        }

        public async Task<List<TramiteEstado>> GetAllTramiteEstado()
        {
            try
            {
                return await _context.TramiteEstados.ToListAsync();
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }

        public async Task<TramiteEstado> GetTramiteEstadoById(int id)
        {
            try
            {
                var result = await _context.TramiteEstados.FirstOrDefaultAsync(t => t.Id == id);
                return result;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }
    }
}
