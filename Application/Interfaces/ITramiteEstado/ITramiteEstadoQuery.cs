using Domain.Entities;

namespace Application.Interfaces.ITramiteEstado
{
    public interface ITramiteEstadoQuery
    {
        Task<List<TramiteEstado>> GetAllTramiteEstado();
        Task<TramiteEstado> GetTramiteEstadoById(int id);
    }
}
