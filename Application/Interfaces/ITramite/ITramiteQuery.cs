using Domain.Entities;

namespace Application.Interfaces.ITramite
{
    public interface ITramiteQuery
    {
        Task<CabeceraTramite> GetTramiteById(int id);
        Task<List<CabeceraTramite>> GetTramites();
        Task<List<CabeceraTramite>> GetTramitesFilters(int? tramiteEstado, int? animalId);
        Task<CabeceraTramite> GetTramiteByAnimalId(int id);
    }
}
