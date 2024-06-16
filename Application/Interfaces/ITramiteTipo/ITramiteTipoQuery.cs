using Domain.Entities;

namespace Application.Interfaces.ITramiteTipo
{
    public interface ITramiteTipoQuery
    {
        Task<List<TramiteAdopcion>> GetAllTramiteAdopcion();
        Task<TramiteAdopcion> GetTramiteAdopcionById(Guid id);
        Task<List<TramiteTransito>> GetAllTramiteTransito();
        Task<TramiteTransito> GetTramiteTransitoById(Guid id);
    }
}
