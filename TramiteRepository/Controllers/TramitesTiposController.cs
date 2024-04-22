using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TramiteRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TramitesTiposController : ControllerBase
    {
        private readonly ITramiteTipoService _service;
        public TramitesTiposController(ITramiteTipoService service)
        {
            _service = service;
        }
        
        [HttpGet] 
        [ProducesResponseType(typeof(GetAllTramiteTipoResponse), 200)]
        public async Task<IActionResult> GetAllTramiteTipo()
        {
            try
            
            {
                var result = await _service.GetAllTramiteTipo();
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