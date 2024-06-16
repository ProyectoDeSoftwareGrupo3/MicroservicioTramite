using Application.Request;
using Domain.Entities;

namespace Application.Interfaces.ITramite
{
    public interface ITramiteCommand
    {
        Task<CabeceraTramite> CreateTramite(CabeceraTramite tramite);
        Task<TramiteAdopcion> CreateTramiteAdopcion(TramiteAdopcion tramiteAdopcion);
        Task<TramiteTransito> CreateTramiteTransito(TramiteTransito tramiteTransito);
        Task<CabeceraTramite> UpdateTramite(UpdateTramiteRequest request);
        Task<TramiteTransito> UpdateTramiteTransito(UpdateTramiteTransitoRequest request);
        Task<TramiteAdopcion> UpdateTramiteAdopcion(UpdateTramiteAdopcionRequest request);
        Task<CabeceraTramite> DeleteTramite(int id);


    }
}
