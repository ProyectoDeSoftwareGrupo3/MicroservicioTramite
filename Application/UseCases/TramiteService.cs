using Application.Exceptions;
using Application.Interfaces.IMappers;
using Application.Interfaces.ITramite;
using Application.Interfaces.ITramiteEstado;
using Application.Interfaces.ITramiteTipo;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.UseCases
{
    public class TramiteService : ITramiteService
    {
        private readonly ITramiteCommand _command;
        private readonly ITramiteQuery _query;
        private readonly ITramiteEstadoService _estadoservice;
        private readonly ITramiteTipoService _tipoService;
        private readonly ITramiteMapper _mapper;

        public TramiteService(ITramiteCommand command, ITramiteQuery query, ITramiteMapper mapper, ITramiteTipoService tipoService, ITramiteEstadoService estadoService)
        {
            _command = command;
            _query = query;
            _mapper = mapper;
            _estadoservice = estadoService;
            _tipoService = tipoService;
        }

        public async Task<TramiteResponse> GetTramiteById(int id)
        {
            try
            {
                if (!await CheckTramite(id))
                {
                    throw new ExceptionNotFound("No existe ese tramite");
                }
                var tramite = await _query.GetTramiteById(id);
                return await _mapper.TramiteResponse(tramite);
            }
            catch (ExceptionNotFound e)
            {

                throw new ExceptionNotFound(e.Message);
            }
        }
        public async Task<TramiteResponse> GetTramiteByAnimalId(int id)
        {
            try
            {
                if (!await CheckAnimalId(id))
                {
                    throw new ExceptionNotFound("No existe ese Tramite con ese Id de animal");
                }
                var tramite = await _query.GetTramiteById(id);
                return await _mapper.TramiteResponse(tramite);
            }
            catch (ExceptionNotFound e)
            {

                throw new ExceptionNotFound(e.Message);
            }
        }

        public async Task<TramiteResponse> CreateTramite(TramiteRequest request)
        {
            try
            {
                if (!await CheckTipo(request.TramiteTipoId))
                {
                    throw new Conflict("Ingreso un tipo de tramite incorrecto");
                }
                var tramite = new Tramite
                {
                    UsuarioId = request.UsuarioId,
                    UsuarioAdoptanteId = request.UsuarioAdoptante,
                    TramiteTipoId = request.TramiteTipoId,
                    AnimalId = request.AnimalId,
                    TramiteEstadoId = 2,
                    Chicos = request.HayChicos,
                    EdadHijoMenor = request.EdadHijoMenor,
                    Cantidadpersonas = request.Cantidadpersonas,
                    HayAnimales = request.HayAnimales,
                    Vacunados = request.Vacunados,
                    Castrados = request.Castrados,
                    AireLibre = request.AireLibre,
                    MotivoAdopcion = request.MotivoAdopcion,
                    HorasSolo = request.HorasSolo,
                    FechaInicio = DateTime.Now,
                };
                var result = await _command.CreateTramite(tramite);
                return await _mapper.TramiteResponse(await _query.GetTramiteById(result.Id));
            }
            catch (Conflict e)
            {

                throw new Conflict(e.Message);
            }
        }

        public async Task<UpdateTramiteResponse> UpdateTramite(UpdateTramiteRequest request)
        {
            try
            {
                if (!await CheckTramite(request.Id))
                {
                    throw new ExceptionNotFound("No existe ese tramite");
                }
                if (!await CheckEstado(request))
                {
                    throw new ExceptionNotFound("No existe ese estado");
                }
                if (!await CheckTipo(request.TramiteTipoId))
                {
                    throw new ExceptionNotFound("No existe ese tipo");
                }
                var tramiteUpdated = await _command.UpdateTramite(request);
                return await _mapper.UpdateTramiteResponse(tramiteUpdated);
            }
            catch (ExceptionNotFound e)
            {

                throw new ExceptionNotFound(e.Message);
            }
        }

        public async Task<TramiteByMonthResponse> GetTramiteByMonth(DateTime dateTime)
        {
            try
            {
                var tramite = await _query.GetTramites();
                List<Tramite> lista = new List<Tramite>();
                foreach (var item in tramite)
                {
                    if (item.FechaInicio.Month == dateTime.Month && item.FechaInicio.Year == dateTime.Year)
                    {
                        lista.Add(item);
                    }
                }
                if (lista.Count==0)
                {
                    throw new ExceptionNotFound("No hubieron tramites en el mes ingresado");
                }
                return await _mapper.TramiteByMonthResponse(lista);
                
            }
            catch (ExceptionNotFound e)
            {

                throw new ExceptionNotFound(e.Message);
            }
        }

        private async Task<bool> CheckEstado(UpdateTramiteRequest request)
        {
            return (await _estadoservice.GetTramiteEstadoResponseById(request.TramiteEstadoId) != null);
        }

        private async Task<bool> CheckTipo(int id)
        {
            return (await _tipoService.GetTramiteTipoResponseById(id) != null);
        }

        private async Task<bool> CheckTramite(int id)
        {
            return (await _query.GetTramiteById(id) != null);
        }

        private async Task<bool> CheckAnimalId(int id)
        {
            return (await _query.GetTramiteByAnimalId(id) != null);
        }


    }
}
