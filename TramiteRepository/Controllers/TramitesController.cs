using Application.Exceptions;
using Application.Interfaces.ITramite;
using Application.Interfaces.IEmail;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace TramiteRepository.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TramitesController : ControllerBase
{

    private readonly ITramiteService _tramiteService;
    private readonly IEmailService _emailService;
    public TramitesController(ITramiteService tramiteService, IEmailService emailService)
    {
        _tramiteService = tramiteService;
        _emailService = emailService;
    }


    
    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(TramiteResponse), 200)]
    [ProducesResponseType(typeof(ExceptionMessage), 404)]
    public async Task<IActionResult> GetTramiteById(int Id)
    {
        try
        {
            var result = await _tramiteService.GetTramiteById(Id);
            return new JsonResult(result) { StatusCode = 200 };
        }
        catch (ExceptionNotFound ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
        }
    }

    [HttpPost("Adopcion")]
    [ProducesResponseType(typeof(TramiteAdopcionResponse), 201)]
    [ProducesResponseType(typeof(ExceptionMessage), 409)]
    public async Task<IActionResult> CreateTramiteAdopcion(TramiteAdopcionRequest request)
    {
        try
        {
            var result = await _tramiteService.CreateTramiteAdopcion(request);
            return new JsonResult(result) { StatusCode = 201 };
        }
        catch (Conflict ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 409 };
        }
    }
    [HttpPost("Transito")]
    [ProducesResponseType(typeof(TramiteTransitoResponse), 201)]
    [ProducesResponseType(typeof(ExceptionMessage), 409)]
    public async Task<IActionResult> CreateTramitTransito(TramiteTransitoRequest request)
    {
        try
        {
            var result = await _tramiteService.CreateTramiteTransito(request);
            return new JsonResult(result) { StatusCode = 201 };
        }
        catch (Conflict ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 409 };
        }
    }


    [HttpPut("Transito")]
    [ProducesResponseType(typeof(TramiteTransitoResponse), 200)]
    [ProducesResponseType(typeof(ExceptionMessage), 404)]
    public async Task<IActionResult> UpdateTramiteTransito(UpdateTramiteTransitoRequest request)
    {
        try
        {
            var result = await _tramiteService.UpdateTramiteTransito(request);
            return new JsonResult(result) { StatusCode = 200 };
        }
        catch (ExceptionNotFound ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
        }
    }
    [HttpPut("Adopcion")]
    [ProducesResponseType(typeof(TramiteAdopcionResponse), 200)]
    [ProducesResponseType(typeof(ExceptionMessage), 404)]
    public async Task<IActionResult> UpdateTramiteAdopcion(UpdateTramiteAdopcionRequest request)
    {
        try
        {
            var result = await _tramiteService.UpdateTramiteAdopcion(request);
            return new JsonResult(result) { StatusCode = 200 };
        }
        catch (ExceptionNotFound ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
        }
    }


    [HttpGet("Thismonth")]
    [ProducesResponseType(typeof(TramiteResponse), 200)]
    [ProducesResponseType(typeof(ExceptionMessage), 404)]
    [Authorize]
    public async Task<IActionResult> GetTramiteByMonth()
    {
        try
        {                       
            var result = await _tramiteService.GetTramiteByMonth(DateTime.Now);
            return new JsonResult(result) { StatusCode = 200 };
        }
        catch (ExceptionNotFound ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
        }
    }
    [HttpGet("Filters")]
    [ProducesResponseType(typeof(TramiteResponse), 200)]
    [ProducesResponseType(typeof(ExceptionMessage), 404)]
    public async Task<IActionResult> GetAllTramitesByTramiteEstado(int? tramiteEstadoId, int? animalId)
    {
        try
        {
            var result = await _tramiteService.GetAllTramitesByFilters(tramiteEstadoId, animalId);
            return new JsonResult(result) { StatusCode = 200 };
        }
        catch (ExceptionNotFound ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
        }
    }

    [HttpGet("GetTramiteCountPerMonth/{year}")]
    public async Task<IActionResult> GetTramiteCountPerMonth(int year)
    {
        var result = await _tramiteService.GetTramiteCountPerMonthAsync(year);
        return Ok(result);
    }
    
    private async Task NotifyUser(string userEmail, string message)
    {        
        await _emailService.SendEmailAsync(userEmail, "Estado de la solicitud", message);
    }
    [HttpPut("UpdateState")]
    public async Task<IActionResult> UpdateTramiteEstado(UpdateTramiteEstadoRequest request)
    {
        try
        {
            var result = await _tramiteService.UpdateTramiteEstado(request);
            return new JsonResult(result){StatusCode = 200};
        }
        catch (ExceptionNotFound ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
        }
    }

}
