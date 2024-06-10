using Application.Exceptions;
using Application.Interfaces.ITramite;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TramiteRepository.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TramitesController : ControllerBase
{

    private readonly ITramiteService _tramiteService;
    public TramitesController(ITramiteService tramiteService)
    {
        _tramiteService = tramiteService;
    }


    [HttpPost]
    [ProducesResponseType(typeof(TramiteResponse), 201)]
    [ProducesResponseType(typeof(ExceptionMessage), 409)]
    public async Task<IActionResult> CreateTramite(TramiteRequest request)
    {
        try
        {
            var result = await _tramiteService.CreateTramite(request);
            return new JsonResult(result) { StatusCode = 201 };
        }
        catch (Conflict ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 409 };
        }
    }

    [HttpPut]
    [ProducesResponseType(typeof(UpdateTramiteResponse), 200)]
    [ProducesResponseType(typeof(ExceptionMessage), 404)]
    public async Task<IActionResult> UpdateTramite(UpdateTramiteRequest request)
    {
        try
        {
            var result = await _tramiteService.UpdateTramite(request);
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
    public async Task<IActionResult> GetTramiteByMonth()
    {
        try
        {
            var result = await _tramiteService.GetTramiteByMonth(DateTime.Now);
            return new JsonResult(result) { StatusCode=200 };
        }
        catch (ExceptionNotFound ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
        }
    }
    [HttpGet("ByTramiteEstado")]
    [ProducesResponseType(typeof(TramiteResponse), 200)]
    [ProducesResponseType(typeof(ExceptionMessage), 404)]
    public async Task<IActionResult> GetAllTramitesByTramiteEstado(int? tramiteEstadoId)
    {
        try
        {
            var result = await _tramiteService.GetAllTramitesByEstadoId(tramiteEstadoId);
            return new JsonResult(result) { StatusCode = 200 };
        }
        catch (ExceptionNotFound ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
        }
    }

    [HttpGet("{animalId}")]
    [ProducesResponseType(typeof(TramiteResponse), 200)]
    [ProducesResponseType(typeof(ExceptionMessage), 404)]
    public async Task<IActionResult> GetTramiteById(int animalId)
    {
        try
        {
            var result = await _tramiteService.GetTramiteById(animalId);
            return new JsonResult(result) { StatusCode = 200 };
        }
        catch (ExceptionNotFound ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(TramiteResponse), 200)]
    [ProducesResponseType(typeof(ExceptionMessage), 404)]
    public async Task<IActionResult> GetTramiteByAnimalId(int id)
    {
        try
        {
            var result = await _tramiteService.GetTramiteByAnimalId(id);
            return new JsonResult(result) { StatusCode = 200 };
        }
        catch (ExceptionNotFound ex)
        {

            return new JsonResult(new ExceptionMessage { Message = ex.Message }) { StatusCode = 404 };
        }
    }


}
