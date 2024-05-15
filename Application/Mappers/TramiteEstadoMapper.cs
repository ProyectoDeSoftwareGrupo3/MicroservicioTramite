using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class TramiteEstadoMapper : ITramiteEstadoMapper
    {
        public Task<List<GetAllTramiteEstadoResponse>> GetGetAllTramiteEstadoResponse(List<TramiteEstado> estados)
        {
            List<GetAllTramiteEstadoResponse> list = new List<GetAllTramiteEstadoResponse>();
            foreach (var item in estados)
            {
                var response = new GetAllTramiteEstadoResponse
                {
                    Descripcion = item.Descripcion,
                    Id = item.Id,
                };

                list.Add(response);
            }
            return Task.FromResult(list);
        }

        public Task<GetAllTramiteEstadoResponse> TramiteEstadoResponse(TramiteEstado estado)
        {
            var response = new GetAllTramiteEstadoResponse
            {
                Descripcion = estado.Descripcion,
                Id = estado.Id,
            };
            return Task.FromResult(response);
        }
    }
}
