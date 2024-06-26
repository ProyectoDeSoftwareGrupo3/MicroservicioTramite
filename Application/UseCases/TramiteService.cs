﻿using System.Runtime.CompilerServices;
using Application.Exceptions;
using Application.Interfaces.IEmail;
using Application.Interfaces.IMappers;
using Application.Interfaces.ITramite;
using Application.Interfaces.ITramiteEstado;
using Application.Interfaces.Services;
using Application.Request;
using Application.Response;
using Domain.Dtos;
using Domain.Entities;
using Domain.Models;

namespace Application.UseCases
{
    public class TramiteService : ITramiteService
    {
        private readonly ITramiteCommand _command;
        private readonly ITramiteQuery _query;
        private readonly ITramiteEstadoService _estadoservice;
        private readonly ITramiteMapper _mapper;
        private readonly IAnimalService _animalService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public TramiteService(ITramiteCommand command, ITramiteQuery query, ITramiteEstadoService estadoservice, ITramiteMapper mapper, IAnimalService animalService, IUserService userService, IEmailService emailService)
        {
            _command = command;
            _query = query;
            _estadoservice = estadoservice;
            _mapper = mapper;
            _animalService = animalService;
            _userService = userService;
            _emailService = emailService;
        }

        public async Task<TramiteResponse> DeleteTramite(int Id)
        {
            try
            {
                if (!await CheckTramite(Id))
                {
                    throw new ExceptionNotFound("No existe ese tramite");
                }
                var response = await _query.GetTramiteById(Id);
                var tramite = await _command.DeleteTramite(Id);

                return await _mapper.TramiteResponse(response);
            }
            catch (ExceptionNotFound e)
            {

                throw new ExceptionNotFound(e.Message);
            }
        }

        public async Task<TramiteAdopcionResponse> CreateTramiteAdopcion(TramiteAdopcionRequest request)
        {
            try
            {
                var CabeceraTramite = await CreateTramite(request.UsuarioId, request.UsuarioSolicitanteId);
                var tramiteAdopcion = new TramiteAdopcion
                {
                    AnimalId = request.AnimalId,
                    AireLibre = request.AireLibre,
                    CantidadPersonas = request.CantidadPersonas,
                    Castrados = request.Castrados,
                    EdadHijoMenor = request.EdadHijoMenor,
                    HayChicos = request.HayChicos,
                    HayMascotas = request.HayMascotas,
                    HorasSolo = request.HorasSolo,
                    MotivoAdopcion = request.MotivoAdopcion,
                    PaseoXMes = request.PaseoXMes,
                    Lugar = request.Lugar,
                    PropietarioInquilino = request.PropietarioInquilino,
                    Vacunados = request.Vacunados,
                    CabeceraTramiteId = CabeceraTramite.Id                    
                };
                var result = await _command.CreateTramiteAdopcion(tramiteAdopcion);

                return await _mapper.TramiteAdopcionResponse(result);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<TramiteTransitoResponse> CreateTramiteTransito(TramiteTransitoRequest request)
        {
            try
            {
                var CabeceraTramite = await CreateTramite(request.UsuarioId, request.UsuarioSolicitanteId);                

                var tramiteTransito = new TramiteTransito
                {
                    Cantidadpersonas = request.Cantidadpersonas,
                    ChicosYEdad = request.ChicosYEdad,
                    DisponibilidadHoraria = request.DisponibilidadHoraria,
                    Emergencia = request.Emergencia,
                    Expectativa = request.Expectativa,
                    ExperienciaDeTransito = request.ExperienciaDeTransito,
                    HayMascotas = request.HayMascotas,
                    ManejoAnimal = request.ManejoAnimal,
                    MedioDeTransporte = request.MedioDeTransporte,
                    PoliticaOrganizacion = request.PoliticaOrganizacion,
                    PropietarioInquilino = request.PropietarioInquilino,
                    RazonInteres = request.RazonInteres,
                    Rutina = request.Rutina,
                    Seguimiento = request.Seguimiento,
                    TiempoDeAcogida = request.TiempoDeAcogida,
                    TipoDeEspacio = request.TipoDeEspacio,
                    VacunadosCastrados = request.VacunadosCastrados,
                    CabeceraTramiteId = CabeceraTramite.Id
                };
                var result = await _command.CreateTramiteTransito(tramiteTransito);

                return await _mapper.TramiteTransitoResponse(result);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<TramiteAdopcionResponse> UpdateTramiteAdopcion(UpdateTramiteAdopcionRequest request)
        {
            try
            {

                var adopcionUpdated = await _command.UpdateTramiteAdopcion(request);
                return await _mapper.TramiteAdopcionResponse(adopcionUpdated);

            }
            catch (ExceptionNotFound e)
            {

                throw new ExceptionNotFound(e.Message);
            }
        }
        public async Task<TramiteTransitoResponse> UpdateTramiteTransito(UpdateTramiteTransitoRequest request)
        {
            try
            {
                var transitoUpdated = await _command.UpdateTramiteTransito(request);
                return await _mapper.TramiteTransitoResponse(transitoUpdated);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<TramiteResponse>> GetAllTramitesByFilters(int? estadoTramiteId, int? animalId)
        {
            try
            { 
                if (estadoTramiteId == null && animalId == null)
                {                                
                    return await _mapper.GetTramitesResponse(await _query.GetTramites());
                }
                if (estadoTramiteId < 1 || estadoTramiteId > 3)
                {
                    throw new ExceptionNotFound("No existe tramite con ese estado");
                }
            //    if (!await CheckAnimalId((int)animalId))
            //    {
            //        throw new ExceptionNotFound("No existe ese Tramite con ese Id de animal");
            //    }
                var tramites = await _query.GetTramitesFilters(estadoTramiteId, animalId);

                var cabeceras = tramites.Select(tramite => ConvertToDto(tramite)).ToList();

            //    foreach (var cabecera in cabeceras)
            //    {
            //        var animal = await _animalService.GetAnimalByIdAsync(cabecera.AnimalId);
            //        cabecera.Animal = animal;
            //    }

                return await _mapper.GetTramitesResponse(cabeceras);

            }
            catch (ExceptionNotFound e)
            {

                throw new ExceptionNotFound(e.Message);
            }

        }

        public static CabeceraTramiteDto ConvertToDto(CabeceraTramite tramite)
        {
            return new CabeceraTramiteDto(tramite);
        }

        public async Task<TramiteResponse> GetTramiteById(int id)
        {
            try
            {
                if (!await CheckTramite(id))
                {
                    throw new ExceptionNotFound("No existe ese tramite");
                }
                var tramite = await _query.GetTramiteById(id);

                return await _mapper.TramiteResponse(tramite);
            }
            catch (ExceptionNotFound e)
            {

                throw new ExceptionNotFound(e.Message);
            }
        }

        public async Task<TramiteResponse> CreateTramite(Guid UsuarioId, Guid UsuarioSolicitanteId)
        {
            try
            {
                var tramite = new CabeceraTramite
                {
                    UsuarioId = UsuarioId,
                    UsuarioSolicitanteId = UsuarioSolicitanteId,
                    FechaInicio = DateTime.Now,
                    EstadoId = 2                
                };
                var result = await _command.CreateTramite(tramite);
                return await _mapper.TramiteResponse(await _query.GetTramiteById(result.Id));
            }
            catch (Conflict e)
            {

                throw new Conflict(e.Message);
            }
        }

        public async Task<UpdateTramiteResponse> UpdateTramite(UpdateTramiteRequest request)
        {
            try
            {
                if (!await CheckTramite(request.Id))
                {
                    throw new ExceptionNotFound("No existe ese tramite");
                }

                var tramiteUpdated = await _command.UpdateTramite(request);
                return await _mapper.UpdateTramiteResponse(tramiteUpdated);
            }
            catch (ExceptionNotFound e)
            {

                throw new ExceptionNotFound(e.Message);
            }
        }
        public async Task<UpdateTramiteResponse> UpdateTramiteEstado(UpdateTramiteEstadoRequest request)
        {
            try
            {
                if (!await CheckTramite(request.TramiteId))
                {
                    throw new ExceptionNotFound("No existe ese tramite");
                }
                var tramiteUpdated = await _command.UpdateTramiteEstado(request);
                NotifyUser(tramiteUpdated);
                return await _mapper.UpdateTramiteResponse(tramiteUpdated);
            }
            catch (ExceptionNotFound e)
            {
                throw new ExceptionNotFound(e.Message);
            }
        }
        private async void NotifyUser(CabeceraTramite tramite)
        {
            string message;
            GetUserResponse remitente = await _userService.GetUserByIdAsync(tramite.UsuarioId);
            GetUserResponse receptor = await _userService.GetUserByIdAsync(tramite.UsuarioSolicitanteId);
            if(tramite.EstadoId == 1)
            {
                message = "ACEPTADA: Su solicitud ha sido aceptada, puede ponerse en contacto con la entidad adoptante a traves de este mail: " + remitente.Email;
            }
            else
            {
                message = "RECHAZA: Su solicitud ha sido rechazada";
            }
            await _emailService.SendEmailAsync(receptor.Email, "Estado de la solicitud", message);

        }

        public async Task<TramiteByMonthResponse> GetTramiteByMonth(DateTime dateTime)
        {
            try
            {
                var tramite = await _query.GetTramites();
                List<CabeceraTramiteDto> lista = new List<CabeceraTramiteDto>();
                foreach (var item in tramite)
                {
                    if (item.FechaInicio.Month == dateTime.Month && item.FechaInicio.Year == dateTime.Year)
                    {
                        lista.Add(item);
                    }
                }
                if (lista.Count == 0)
                {
                    throw new ExceptionNotFound("No hubieron tramites en el mes ingresado");
                }
                return await _mapper.TramiteByMonthResponse(lista);

            }
            catch (ExceptionNotFound e)
            {

                throw new ExceptionNotFound(e.Message);
            }
        }

        public async Task<int[]> GetTramiteCountPerMonthAsync(int year)
        {
            var tramites = await _query.GetAllAsync();
            var counts = new int[12];

            foreach (var tramite in tramites)
            {
                if (tramite.FechaInicio.Year == year)
                {
                    counts[tramite.FechaInicio.Month - 1]++;
                }
            }

            return counts;
        }
        

        private async Task<bool> CheckTramite(int id)
        {
            return (await _query.GetTramiteById(id) != null);
        }

        

        // private async Task<bool> CheckAnimalId(int id)
        // {
        //     return (await _query.GetTramiteByAnimalId(id) != null);
        // }


    }
}
