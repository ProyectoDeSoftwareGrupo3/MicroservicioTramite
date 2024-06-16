using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class TramiteMapper : ITramiteMapper
    {
        private readonly ITramiteTipoMapper _tipoMapper;
        private readonly ITramiteEstadoMapper _estadoMapper;
        public TramiteMapper(ITramiteEstadoMapper estadoMapper, ITramiteTipoMapper tipoMapper)
        {
            _estadoMapper = estadoMapper;
            _tipoMapper = tipoMapper;
        }
        public Task<TramiteByMonthResponse> TramiteByMonthResponse(List<CabeceraTramite> tramites)
        {
            int aprobado = 0;
            int rechazado = 0;
            int revision = 0;
            foreach (var item in tramites)
            {
                if (item.EstadoId == 1)
                {
                    aprobado += 1;
                }
                if (item.EstadoId == 2)
                {
                    rechazado += 1;
                }
                if (item.EstadoId == 3)
                {
                    revision += 1;
                }
            }
            var response = new TramiteByMonthResponse
            {
                EstadoAprobado = aprobado,
                EstadoRechazado = rechazado,
                EstadoRevision = revision,
            };

            return Task.FromResult(response);
        }

        public async Task<List<TramiteResponse>> GetTramitesResponse(List<CabeceraTramite> tramites)
        {
            List<TramiteResponse> listresponse = new List<TramiteResponse>();
            foreach (var tramite in tramites)
            {
                if (tramite.TramiteTransito == null)
                {
                    var response = new TramiteResponse
                    {
                        Id = tramite.Id,
                        UsuarioId = tramite.UsuarioId,
                        UsuarioAdoptanteId = tramite.UsuarioAdoptanteId,
                        AnimalId = tramite.AnimalId,
                        FechaFinal = tramite.FechaFinal,
                        FechaInicio = tramite.FechaInicio,

                        EstadoResponse = await _estadoMapper.TramiteEstadoResponse(tramite.Estado),
                        AdopcionResponse = await _tipoMapper.TramiteAdopcionResponse(tramite.TramiteAdopcion),

                    };
                    listresponse.Add(response);
                }
                else
                {
                    var response = new TramiteResponse
                    {
                        Id = tramite.Id,
                        UsuarioId = tramite.UsuarioId,
                        UsuarioAdoptanteId = tramite.UsuarioAdoptanteId,
                        AnimalId = tramite.AnimalId,
                        FechaFinal = tramite.FechaFinal,
                        FechaInicio = tramite.FechaInicio,

                        EstadoResponse = await _estadoMapper.TramiteEstadoResponse(tramite.Estado),
                        TransitoResponse = await _tipoMapper.TramiteTransitoResponse(tramite.TramiteTransito),

                    };
                    listresponse.Add(response);
                }

            }
            return listresponse;
        }

        public async Task<TramiteResponse> TramiteResponse(CabeceraTramite tramite)
        {
            var response = new TramiteResponse();
            if (tramite.TramiteTransito == null)
            {
                response = new TramiteResponse
                {
                    Id = tramite.Id,
                    UsuarioId = tramite.UsuarioId,
                    UsuarioAdoptanteId = tramite.UsuarioAdoptanteId,
                    AnimalId = tramite.AnimalId,
                    FechaFinal = tramite.FechaFinal,
                    FechaInicio = tramite.FechaInicio,

                    EstadoResponse = await _estadoMapper.TramiteEstadoResponse(tramite.Estado),
                    AdopcionResponse = await _tipoMapper.TramiteAdopcionResponse(tramite.TramiteAdopcion),

                };

            }
            else
            {
                response = new TramiteResponse
                {
                    Id = tramite.Id,
                    UsuarioId = tramite.UsuarioId,
                    UsuarioAdoptanteId = tramite.UsuarioAdoptanteId,
                    AnimalId = tramite.AnimalId,
                    FechaFinal = tramite.FechaFinal,
                    FechaInicio = tramite.FechaInicio,

                    EstadoResponse = await _estadoMapper.TramiteEstadoResponse(tramite.Estado),
                    TransitoResponse = await _tipoMapper.TramiteTransitoResponse(tramite.TramiteTransito),

                };

            }
            return response;
        }

        public async Task<UpdateTramiteResponse> UpdateTramiteResponse(CabeceraTramite tramite)
        {
            var response = new UpdateTramiteResponse
            {
                Id = tramite.Id,
                UsuarioId = tramite.UsuarioId,
                UsuarioAdoptanteId = tramite.UsuarioAdoptanteId,
                AnimalId = tramite.AnimalId,
                FechaFinal = tramite.FechaFinal,
                FechaInicio = tramite.FechaInicio,
                EstadoResponse = await _estadoMapper.TramiteEstadoResponse(tramite.Estado)
            };
            return response;
        }

        public Task<TramiteAdopcionResponse> TramiteAdopcionResponse(TramiteAdopcion tramiteAdopcion)
        {
            var response = new TramiteAdopcionResponse
            {
                AireLibre = tramiteAdopcion.AireLibre,
                CantidadPersonas = tramiteAdopcion.CantidadPersonas,
                Castrados = tramiteAdopcion.Castrados,
                EdadHijoMenor = tramiteAdopcion.EdadHijoMenor,
                HayChicos = tramiteAdopcion.HayChicos,
                HayMascotas = tramiteAdopcion.HayMascotas,
                HorasSolo = tramiteAdopcion.HorasSolo,
                MotivoAdopcion = tramiteAdopcion.MotivoAdopcion,
                PaseoXMes = tramiteAdopcion.PaseoXMes,
                PropietarioInquilino = tramiteAdopcion.PropietarioInquilino,
                TramiteId = tramiteAdopcion.TramiteId,
                Vacunados = tramiteAdopcion.Vacunados


            };
            return Task.FromResult(response);
        }

        public Task<TramiteTransitoResponse> TramiteTransitoResponse(TramiteTransito tramiteTransito)
        {
            var response = new TramiteTransitoResponse
            {
                PropietarioInquilino = tramiteTransito.PropietarioInquilino,
                ActitudHaciaAnimales = tramiteTransito.ActitudHaciaAnimales,
                Cantidadpersonas = tramiteTransito.Cantidadpersonas,
                ChicosYEdad = tramiteTransito.ChicosYEdad,
                DisponibilidadHoraria = tramiteTransito.DisponibilidadHoraria,
                Emergencia = tramiteTransito.Emergencia,
                Expectativa = tramiteTransito.Expectativa,
                ExperienciaDeTransito = tramiteTransito.ExperienciaDeTransito,
                HayMascotas = tramiteTransito.HayMascotas,
                ManejoAnimal = tramiteTransito.ManejoAnimal,
                MedioDeTransporte = tramiteTransito.MedioDeTransporte,
                PoliticaOrganizacion = tramiteTransito.PoliticaOrganizacion,
                RazonInteres = tramiteTransito.RazonInteres,
                Rutina = tramiteTransito.Rutina,
                Seguimiento = tramiteTransito.Seguimiento,
                TiempoDeAcogida = tramiteTransito.TiempoDeAcogida,
                TipoDeEspacio = tramiteTransito.TipoDeEspacio,
                VacunadosCastrados = tramiteTransito.VacunadosCastrados

            };
            return Task.FromResult(response);
        }

        public Task<List<TramiteResponse>> GetTramitesAdopcionResponse(List<TramiteAdopcion> tramitesAdopcion)
        {
            throw new NotImplementedException();
        }

        public Task<List<TramiteResponse>> GetTramitesTransitoResponse(List<TramiteTransito> tramitesTransito)
        {
            throw new NotImplementedException();
        }
    }
}
