using Application.Exceptions;
using Application.Interfaces.IMappers;
using Application.Interfaces.ITramiteEstado;
using Application.Response;

namespace Application.UseCases
{
    public class TramiteEstadoService : ITramiteEstadoService
    {
        private readonly ITramiteEstadoQuery _query;
        private readonly ITramiteEstadoMapper _mapper;
        public TramiteEstadoService(ITramiteEstadoQuery query, ITramiteEstadoMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public async Task<List<GetAllTramiteEstadoResponse>> GetAllTramiteEstado()
        {
            var tramiteestado = await _query.GetAllTramiteEstado();
            var tramiteestadoresponse = await _mapper.GetGetAllTramiteEstadoResponse(tramiteestado);
            return tramiteestadoresponse;
        }

        public async Task<GetAllTramiteEstadoResponse> GetTramiteEstadoResponseById(int id)
        {
            try
            {
                if (!await CheckTramiteId(id))
                {
                    throw new ExceptionNotFound("No Existe Estado con ese Id");
                }

                var tramiteTipo = await _query.GetTramiteEstadoById(id);
                return await _mapper.TramiteEstadoResponse(tramiteTipo);
            }
            catch (Conflict e)
            {

                throw new Conflict(e.Message);
            }

        }

        private async Task<bool> CheckTramiteId(int id)
        {
            return (await _query.GetTramiteEstadoById(id) != null);
        }
    }
}
