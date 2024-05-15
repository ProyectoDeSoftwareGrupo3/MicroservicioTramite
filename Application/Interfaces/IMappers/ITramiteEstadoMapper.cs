using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IMappers
{
    public interface ITramiteEstadoMapper
    {
        Task<List<GetAllTramiteEstadoResponse>> GetGetAllTramiteEstadoResponse(List<TramiteEstado> estados);
        Task<GetAllTramiteEstadoResponse> TramiteEstadoResponse(TramiteEstado estado);
    }
}
