using Application.Request;
using Application.Response;

namespace Application.Interfaces.ITramite
{
    public interface ITramiteService
    {
        Task<TramiteResponse> CreateTramite(Guid UsuarioId, Guid UsuarioSolicitante);
        Task<TramiteAdopcionResponse> CreateTramiteAdopcion(TramiteAdopcionRequest request);
        Task<TramiteTransitoResponse> CreateTramiteTransito(TramiteTransitoRequest request);

        Task<UpdateTramiteResponse> UpdateTramite(UpdateTramiteRequest request);
        Task<TramiteAdopcionResponse> UpdateTramiteAdopcion(UpdateTramiteAdopcionRequest request);
        Task<TramiteTransitoResponse> UpdateTramiteTransito(UpdateTramiteTransitoRequest request);
        Task<UpdateTramiteResponse> UpdateTramiteEstado(UpdateTramiteEstadoRequest request);

        Task<TramiteResponse> GetTramiteById(int id);
        Task<TramiteByMonthResponse> GetTramiteByMonth(DateTime dateTime);
        Task<List<TramiteResponse>> GetAllTramitesByFilters(int? estadoTramiteId, int? animalId);
        Task<TramiteResponse> DeleteTramite(int Id);
        Task<int[]> GetTramiteCountPerMonthAsync(int year);
    }
}
