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

        public async Task<CabeceraTramite> DeleteTramite(int id)
        {
            var tramite = await _context.CabeceraTramites

                .Include(ct => ct.TramiteTransito)
                .Include(ct => ct.TramiteAdopcion)
                .Where(ct => ct.Id == id).FirstAsync();

            _context.Remove(tramite);
            await _context.SaveChangesAsync();

            return tramite;
        }
        public async Task<TramiteAdopcion> CreateTramiteAdopcion(TramiteAdopcion tramiteAdopcion)
        {
            try
            {
                _context.TramiteAdopciones.Add(tramiteAdopcion);
                await _context.SaveChangesAsync();
                return tramiteAdopcion;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }
        public async Task<TramiteTransito> CreateTramiteTransito(TramiteTransito tramiteTransito)
        {
            try
            {
                _context.TramiteTransitos.Add(tramiteTransito);
                await _context.SaveChangesAsync();
                return tramiteTransito;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }

        public async Task<CabeceraTramite> CreateTramite(CabeceraTramite tramite)
        {
            try
            {
                await _context.CabeceraTramites.AddAsync(tramite);
                await _context.SaveChangesAsync();
                return tramite;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }
        public async Task<TramiteTransito> UpdateTramiteTransito(UpdateTramiteTransitoRequest request)
        {
            try
            {
                var transitoUpdated = _context.TramiteTransitos.FirstOrDefault(tt => tt.TramiteId == request.TramiteId);
                transitoUpdated.RazonInteres = request.RazonInteres;
                transitoUpdated.ExperienciaDeTransito = request.ExperienciaDeTransito;
                transitoUpdated.Cantidadpersonas = request.Cantidadpersonas;
                transitoUpdated.ChicosYEdad = request.ChicosYEdad;
                transitoUpdated.HayMascotas = request.HayMascotas;
                transitoUpdated.VacunadosCastrados = request.VacunadosCastrados;
                transitoUpdated.TipoDeEspacio = request.TipoDeEspacio;
                transitoUpdated.PropietarioInquilino = request.PropietarioInquilino;
                transitoUpdated.DisponibilidadHoraria = request.DisponibilidadHoraria;
                transitoUpdated.Rutina = request.Rutina;
                transitoUpdated.Emergencia = request.Emergencia;
                transitoUpdated.MedioDeTransporte = request.MedioDeTransporte;
                transitoUpdated.Seguimiento = request.Seguimiento;
                transitoUpdated.ManejoAnimal = request.ManejoAnimal;
                transitoUpdated.TiempoDeAcogida = request.TiempoDeAcogida;
                transitoUpdated.Expectativa = request.Expectativa;
                transitoUpdated.PoliticaOrganizacion = request.PoliticaOrganizacion;
                await _context.SaveChangesAsync();
                return transitoUpdated;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }
        public async Task<TramiteAdopcion> UpdateTramiteAdopcion(UpdateTramiteAdopcionRequest request)
        {
            try
            {
                var adopcionUpdated = _context.TramiteAdopciones.FirstOrDefault(ta => ta.TramiteId == request.TramiteId);
                adopcionUpdated.AireLibre = request.AireLibre;
                adopcionUpdated.MotivoAdopcion = request.MotivoAdopcion;
                adopcionUpdated.Castrados = request.Castrados;
                adopcionUpdated.HayChicos = request.HayChicos;
                adopcionUpdated.Vacunados = request.Vacunados;
                adopcionUpdated.CantidadPersonas = request.CantidadPersonas;
                adopcionUpdated.EdadHijoMenor = request.EdadHijoMenor;
                adopcionUpdated.HayMascotas = request.HayMascotas;
                adopcionUpdated.HorasSolo = request.HorasSolo;
                adopcionUpdated.PaseoXMes = request.PaseoXMes;
                adopcionUpdated.PropietarioInquilino = request.PropietarioInquilino;
                await _context.SaveChangesAsync();

                return adopcionUpdated;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }


        public async Task<CabeceraTramite> UpdateTramite(UpdateTramiteRequest request)
        {
            try
            {
                var tramiteUpdated = _context.CabeceraTramites.FirstOrDefault(t => t.Id == request.Id);
                tramiteUpdated.UsuarioId = request.UsuarioId;
                tramiteUpdated.UsuarioSolicitanteId = request.UsuarioSolicitanteId;
                tramiteUpdated.EstadoId = request.EstadoId;
                tramiteUpdated.FechaFinal = request.FechaFinal;
                tramiteUpdated.FechaInicio = request.FechaInicio;
                                
                await _context.SaveChangesAsync();
                return tramiteUpdated;

            }
            catch (DbUpdateException)
            {

                throw new Conflict("Error en la base de datos");
            }
        }
        public async Task<CabeceraTramite> UpdateTramiteEstado(UpdateTramiteEstadoRequest request)
        {
            try
            {
                var tramiteUpdated = await _context.CabeceraTramites
                                                    .Include(t => t.Estado)
                                                    .FirstOrDefaultAsync(t => t.Id == request.TramiteId);
                tramiteUpdated.EstadoId = request.EstadoId;
                await _context.SaveChangesAsync();
                var updated = await _context.CabeceraTramites
                                                    .Include(t => t.Estado)
                                                    .FirstOrDefaultAsync(t => t.Id == request.TramiteId);
                return updated;
            }
            catch (DbUpdateException)
            {
                throw new Conflict("Error en la base de datos");
            }
        }
    }
}
