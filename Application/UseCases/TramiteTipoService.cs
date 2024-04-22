using Application.Interfaces;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class TramiteTipoService: ITramiteTipoService
    {
        private readonly ITramiteTipoQuery _query;
        public TramiteTipoService(ITramiteTipoQuery query)
        {
            _query = query;
        }
        public async Task<List<GetAllTramiteTipoResponse>> GetAllTramiteTipo()
        {
            var tramitetipo = await _query.GetAllTramiteTipo();
            var tramitetiporesponse = new List<GetAllTramiteTipoResponse>();
            foreach(var tramite in tramitetipo)
            {
                var getalltramitetiporesponse = new GetAllTramiteTipoResponse
                {
                    Id = tramite.Id,
                    Descripcion = tramite.Descripcion,
                };
                tramitetiporesponse.Add(getalltramitetiporesponse);
            }
            return tramitetiporesponse;
        }
    }
}
