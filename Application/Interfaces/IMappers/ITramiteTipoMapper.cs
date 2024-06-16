using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IMappers
{
    public interface ITramiteTipoMapper
    {
        Task<List<TramiteAdopcionResponse>> GetTramiteAdopciones(List<TramiteAdopcion> adopciones);
        Task<TramiteAdopcionResponse> TramiteAdopcionResponse(TramiteAdopcion adopcion);
        Task<List<TramiteTransitoResponse>> GetTramiteTransitos(List<TramiteTransito> transitos);
        Task<TramiteTransitoResponse> TramiteTransitoResponse(TramiteTransito transito);
    }
}
