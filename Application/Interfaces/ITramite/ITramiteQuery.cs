using Domain.Entities;

namespace Application.Interfaces.ITramite
{
    public interface ITramiteQuery
    {
        Task<Tramite> GetTramiteById(int id);
        Task<Tramite> GetTramiteByAnimalId(int id);
        Task<List<Tramite>> GetTramites();
        Task<List<Tramite>> GetTramitesByEstado(int? tramiteEstado);
    }
}
