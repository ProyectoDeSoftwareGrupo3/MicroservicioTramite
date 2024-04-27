using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TramiteRepository.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TramitesTiposController(ITramiteTipoService service) : ControllerBase
{
    private readonly ITramiteTipoService _service = service;

    [HttpGet]
    [Authorize]
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