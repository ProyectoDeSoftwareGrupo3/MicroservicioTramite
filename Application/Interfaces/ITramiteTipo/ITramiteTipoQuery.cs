using Domain.Entities;

namespace Application.Interfaces.ITramiteTipo
{
    public interface ITramiteTipoQuery
    {
        Task<List<TramiteTipo>> GetAllTramiteTipo();
        Task<TramiteTipo> GetTramiteTipoById(int id);
    }
}
