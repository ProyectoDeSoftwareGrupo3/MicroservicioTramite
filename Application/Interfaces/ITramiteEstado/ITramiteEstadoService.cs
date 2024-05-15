using Application.Response;

namespace Application.Interfaces.ITramiteEstado
{
    public interface ITramiteEstadoService
    {
        Task<List<GetAllTramiteEstadoResponse>> GetAllTramiteEstado();
        Task<GetAllTramiteEstadoResponse> GetTramiteEstadoResponseById(int id);
    }
}
