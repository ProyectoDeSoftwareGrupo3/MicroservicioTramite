using Application.Response;
using Domain.Dtos;
using Domain.Entities;

namespace Application.Interfaces.IMappers
{
    public interface ITramiteMapper
    {
        Task<TramiteResponse> TramiteResponse(CabeceraTramite tramite);
        Task<TramiteAdopcionResponse> TramiteAdopcionResponse(TramiteAdopcion tramiteAdopcion);
        Task<TramiteTransitoResponse> TramiteTransitoResponse(TramiteTransito tramiteTransito);


        Task<List<TramiteResponse>> GetTramitesResponse(List<CabeceraTramiteDto> tramites);
        Task<List<TramiteResponse>> GetTramitesAdopcionResponse(List<TramiteAdopcion> tramitesAdopcion);
        Task<List<TramiteResponse>> GetTramitesTransitoResponse(List<TramiteTransito> tramitesTransito);

        Task<UpdateTramiteResponse> UpdateTramiteResponse(CabeceraTramite tramite);
        Task<TramiteByMonthResponse> TramiteByMonthResponse(List<CabeceraTramiteDto> tramites);



    }
}
