using Application.Exceptions;
using Application.Interfaces.ITramite;
using Application.Request;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class TramiteCommand : ITramiteCommand
    {
        private readonly TramiteDbContext _context;

        public TramiteCommand(TramiteDbContext context)
        {
            _context = context;
        }

        public async Task<Tramite> CreateTramite(Tramite tramite)
        {
            try
            {
                _context.Tramites.Add(tramite);
                await _context.SaveChangesAsync();
                return tramite;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }
        public async Task<Tramite> UpdateTramite(UpdateTramiteRequest request)
        {
            try
            {
                var tramiteUpdated = _context.Tramites.FirstOrDefault(t => t.Id == request.Id);
                tramiteUpdated.UsuarioId = request.UsuarioId;
                tramiteUpdated.TramiteTipoId = request.TramiteTipoId;
                tramiteUpdated.TramiteEstadoId = request.TramiteEstadoId;
                tramiteUpdated.AnimalId = request.AnimalId;
                tramiteUpdated.Comentario = request.Comentario;
                tramiteUpdated.FechaInicio = request.FechaInicio;
                tramiteUpdated.FechaFinalizacion = request.FechaFinalizacion;
                await _context.SaveChangesAsync();
                return tramiteUpdated;

            }
            catch (DbUpdateException)
            {

                throw new Conflict("Error en la base de datos");
            }
        }
    }
}
