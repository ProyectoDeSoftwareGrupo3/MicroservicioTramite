using Application.Request;
using Application.Response;

namespace Application.Interfaces.ITramite
{
    public interface ITramiteService
    {
        Task<TramiteResponse> CreateTramite(TramiteRequest request);
        Task<UpdateTramiteResponse> UpdateTramite(UpdateTramiteRequest request);
        Task<TramiteResponse> GetTramiteById(int id);
        Task<TramiteResponse> GetTramiteByAnimalId(int id);
        Task<TramiteByMonthResponse> GetTramiteByMonth(DateTime dateTime);
    }
}
