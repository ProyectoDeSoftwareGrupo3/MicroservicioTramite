using Application.Interfaces;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class TramiteEstadoService: ITramiteEstadoService
    {
        private readonly ITramiteEstadoQuery _query;
        public TramiteEstadoService(ITramiteEstadoQuery query)
        {
            _query = query;
        }

        public async Task<List<GetAllTramiteEstadoResponse>> GetAllTramiteEstado()
        {
            var tramiteestado = await _query.GetAllTramiteEstado();
            var tramiteestadoresponse = new List<GetAllTramiteEstadoResponse>();
            foreach (var tramite in tramiteestado)
            {
                var getalltramiteestadoresponse = new GetAllTramiteEstadoResponse
                {
                    Id = tramite.Id,
                    Descripcion = tramite.Descripcion,
                };

                tramiteestadoresponse.Add(getalltramiteestadoresponse);
            }
            return tramiteestadoresponse;
        }
    }
}
