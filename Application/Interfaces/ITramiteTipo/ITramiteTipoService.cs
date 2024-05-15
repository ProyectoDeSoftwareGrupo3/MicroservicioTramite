using Application.Response;

namespace Application.Interfaces.ITramiteTipo
{
    public interface ITramiteTipoService
    {
        Task<List<GetAllTramiteTipoResponse>> GetAllTramiteTipo();
        Task<GetAllTramiteTipoResponse> GetTramiteTipoResponseById(int id);

    }
}
