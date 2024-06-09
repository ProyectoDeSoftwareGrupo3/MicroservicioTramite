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
                tramiteUpdated.UsuarioAdoptanteId = request.UsuarioAdoptanteId;
                tramiteUpdated.AnimalId = request.AnimalId;
                tramiteUpdated.Chicos = request.HayChicos;
                tramiteUpdated.EdadHijoMenor = request.EdadHijoMenor;
                tramiteUpdated.Cantidadpersonas = request.Cantidadpersonas;
                tramiteUpdated.HayAnimales = request.HayAnimales;
                tramiteUpdated.Vacunados = request.Vacunados;
                tramiteUpdated.Castrados=request.Castrados;
                tramiteUpdated.LugarAdopcion=request.LugarAdopcion;
                tramiteUpdated.PropietarioInquilino = request.PropietarioOInquilino;
                tramiteUpdated.AireLibre = request.AireLibre;
                tramiteUpdated.MotivoAdopcion= request.MotivoAdopcion;
                tramiteUpdated.HorasSolo=request.HorasSolo;
                tramiteUpdated.PaseoMes = request.PaseoxMes;

                tramiteUpdated.TramiteTipoId = request.TramiteTipoId;
                tramiteUpdated.TramiteEstadoId = request.TramiteEstadoId;
                
                
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
