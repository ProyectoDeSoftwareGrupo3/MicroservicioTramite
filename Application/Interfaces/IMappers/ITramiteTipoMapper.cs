using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IMappers
{
    public interface ITramiteTipoMapper
    {
        Task<List<GetAllTramiteTipoResponse>> GetTramiteTipos(List<TramiteTipo> tipos);
        Task<GetAllTramiteTipoResponse> TramiteTipoResponse(TramiteTipo tipo);
    }
}
