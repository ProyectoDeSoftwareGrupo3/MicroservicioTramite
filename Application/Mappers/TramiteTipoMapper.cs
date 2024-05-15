using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class TramiteTipoMapper : ITramiteTipoMapper
    {
        public Task<List<GetAllTramiteTipoResponse>> GetTramiteTipos(List<TramiteTipo> tipos)
        {
            List<GetAllTramiteTipoResponse> list = new List<GetAllTramiteTipoResponse>();
            foreach (var item in tipos)
            {
                var response = new GetAllTramiteTipoResponse
                {
                    Descripcion = item.Descripcion,
                    Id = item.Id,
                };
                list.Add(response);
            }

            return Task.FromResult(list);
        }

        public Task<GetAllTramiteTipoResponse> TramiteTipoResponse(TramiteTipo tipo)
        {
            var response = new GetAllTramiteTipoResponse
            {
                Descripcion = tipo.Descripcion,
                Id = tipo.Id,
            };

            return Task.FromResult(response);
        }
    }
}
