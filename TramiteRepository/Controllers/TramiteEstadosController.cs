using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TramiteRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TramiteEstadosController : ControllerBase
    {
        private readonly ITramiteEstadoService _service;
        public TramiteEstadosController(ITramiteEstadoService service)
        {
            _service = service;

        }
        [HttpGet]
        [ProducesResponseType(typeof(GetAllTramiteEstadoResponse), 200)]
        public async Task<IActionResult> GetAllTramiteEstado()
        {
            try
            {
                var result = await _service.GetAllTramiteEstado();
                return new JsonResult(result)
                {
                    StatusCode = 200
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
