using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IMappers
{
    public interface ITramiteMapper
    {
        Task<TramiteResponse> TramiteResponse(Tramite tramite);
        Task<UpdateTramiteResponse> UpdateTramiteResponse(Tramite tramite);
        Task<TramiteByMonthResponse> TramiteByMonthResponse(List<Tramite> tramites);
        Task<List<TramiteResponse>> GetTramitesByEstadoResponse(List<Tramite> tramites);
    }
}
