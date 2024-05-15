using Application.Request;
using Domain.Entities;

namespace Application.Interfaces.ITramite
{
    public interface ITramiteCommand
    {
        Task<Tramite> CreateTramite(Tramite tramite);
        Task<Tramite> UpdateTramite(UpdateTramiteRequest request);
    }
}
