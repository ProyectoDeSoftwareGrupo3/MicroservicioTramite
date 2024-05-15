using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IMappers
{
    public interface ITramiteMapper
    {
        Task<TramiteResponse> TramiteResponse(Tramite tramite);
        Task<UpdateTramiteResponse> UpdateTramiteResponse(Tramite tramite);
    }
}
