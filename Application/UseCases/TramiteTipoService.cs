using Application.Exceptions;
using Application.Interfaces.IMappers;
using Application.Interfaces.ITramiteTipo;
using Application.Response;

namespace Application.UseCases
{
    public class TramiteTipoService : ITramiteTipoService
    {
        private readonly ITramiteTipoQuery _query;
        private readonly ITramiteTipoMapper _mapper;
        public TramiteTipoService(ITramiteTipoQuery query, ITramiteTipoMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }
        public async Task<List<GetAllTramiteTipoResponse>> GetAllTramiteTipo()
        {
            var tramitetipo = await _query.GetAllTramiteTipo();
            var tramitetiporesponse = await _mapper.GetTramiteTipos(tramitetipo);
            return tramitetiporesponse;
        }
        public async Task<GetAllTramiteTipoResponse> GetTramiteTipoResponseById(int id)
        {
            try
            {
                if (!await CheckTramiteId(id))
                {
                    throw new ExceptionNotFound("No Existe Tramite con ese Id");
                }

                var tramiteTipo = await _query.GetTramiteTipoById(id);
                return await _mapper.TramiteTipoResponse(tramiteTipo);
            }
            catch (ExceptionNotFound e)
            {

                throw new ExceptionNotFound(e.Message);
            }
        }
        private async Task<bool> CheckTramiteId(int id)
        {
            return (await _query.GetTramiteTipoById(id) != null);
        }
    }
}
