using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TramiteRepository.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TramiteEstadosController(ITramiteEstadoService service) : ControllerBase
{
    private readonly ITramiteEstadoService _service = service;

    [HttpGet] //https://localhost:7285/api/TramiteEstados
    [Authorize]
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
