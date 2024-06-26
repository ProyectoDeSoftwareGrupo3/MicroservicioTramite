﻿using Application.Interfaces.IMappers;
using Application.Interfaces.Services;
using Application.Response;
using Domain.Dtos;
using Domain.Entities;

namespace Application.Mappers
{
    public class TramiteMapper : ITramiteMapper
    {
        private readonly ITramiteTipoMapper _tipoMapper;
        private readonly ITramiteEstadoMapper _estadoMapper;
        private readonly IUserService _userService;        

        public TramiteMapper(ITramiteTipoMapper tipoMapper, ITramiteEstadoMapper estadoMapper, IUserService userService)
        {
            _tipoMapper = tipoMapper;
            _estadoMapper = estadoMapper;
            _userService = userService;
        }

        public Task<TramiteByMonthResponse> TramiteByMonthResponse(List<CabeceraTramiteDto> tramites)
        {
            int aprobado = 0;
            int rechazado = 0;
            int revision = 0;
            foreach (var item in tramites)
            {
                if (item.EstadoId == 1)
                {
                    aprobado += 1;
                }
                if (item.EstadoId == 2)
                {
                    rechazado += 1;
                }
                if (item.EstadoId == 3)
                {
                    revision += 1;
                }
            }
            var response = new TramiteByMonthResponse
            {
                EstadoAprobado = aprobado,
                EstadoRechazado = rechazado,
                EstadoRevision = revision,
            };

            return Task.FromResult(response);
        }

        public async Task<List<TramiteResponse>> GetTramitesResponse(List<CabeceraTramiteDto> tramites)
        {
            List<TramiteResponse> listresponse = new List<TramiteResponse>();
            foreach (var tramite in tramites)
            {    
                if(tramite.TramiteAdopcion != null)
                {
                    var response = new TramiteResponse
                    {
                        Id = tramite.Id,
                        UsuarioId = tramite.UsuarioId,
                        UsuarioReceptor = await _userService.GetUserByIdAsync(tramite.UsuarioId),
                        UsuarioSolicitanteId = tramite.UsuarioSolicitanteId,
                        UsuarioRemitente = await _userService.GetUserByIdAsync(tramite.UsuarioSolicitanteId),
                        FechaFinal = tramite.FechaFinal,
                        FechaInicio = tramite.FechaInicio,                                                
                        EstadoResponse = await _estadoMapper.TramiteEstadoResponse(tramite.Estado),
                        AdopcionResponse = await _tipoMapper.TramiteAdopcionResponse(tramite.TramiteAdopcion)
                    };
                    listresponse.Add(response); 
                }    
                else
                {
                    var response = new TramiteResponse
                    {
                        Id = tramite.Id,
                        UsuarioId = tramite.UsuarioId,
                        UsuarioReceptor = await _userService.GetUserByIdAsync(tramite.UsuarioId),
                        UsuarioSolicitanteId = tramite.UsuarioSolicitanteId,
                        UsuarioRemitente = await _userService.GetUserByIdAsync(tramite.UsuarioSolicitanteId),
                        FechaFinal = tramite.FechaFinal,
                        FechaInicio = tramite.FechaInicio,                                                
                        EstadoResponse = await _estadoMapper.TramiteEstadoResponse(tramite.Estado),
                        TransitoResponse = await _tipoMapper.TramiteTransitoResponse(tramite.TramiteTransito)
                    };
                    listresponse.Add(response); 
                }        
                
            }
            return listresponse;
        }

        public async Task<TramiteResponse> TramiteResponse(CabeceraTramite tramite)
        {            
            var response = new TramiteResponse
                {
                    Id = tramite.Id,
                    UsuarioId = tramite.UsuarioId,
                    UsuarioReceptor = await _userService.GetUserByIdAsync(tramite.UsuarioId),
                    UsuarioSolicitanteId = tramite.UsuarioSolicitanteId,
                    UsuarioRemitente = await _userService.GetUserByIdAsync(tramite.UsuarioSolicitanteId),
                    FechaFinal = tramite.FechaFinal,
                    FechaInicio = tramite.FechaInicio,

                    EstadoResponse = await _estadoMapper.TramiteEstadoResponse(tramite.Estado),                    
                };            
            return response;
        }

        public async Task<UpdateTramiteResponse> UpdateTramiteResponse(CabeceraTramite tramite)
        {
            var response = new UpdateTramiteResponse
            {
                Id = tramite.Id,
                UsuarioId = tramite.UsuarioId,
                UsuarioSolicitanteId = tramite.UsuarioSolicitanteId,
                FechaFinal = tramite.FechaFinal,
                FechaInicio = tramite.FechaInicio,
                EstadoResponse = await _estadoMapper.TramiteEstadoResponse(tramite.Estado)
            };
            return response;
        }

        public Task<TramiteAdopcionResponse> TramiteAdopcionResponse(TramiteAdopcion tramiteAdopcion)
        {
            var response = new TramiteAdopcionResponse
            {
                AnimalId = tramiteAdopcion.AnimalId,
                AireLibre = tramiteAdopcion.AireLibre,
                CantidadPersonas = tramiteAdopcion.CantidadPersonas,
                Castrados = tramiteAdopcion.Castrados,
                EdadHijoMenor = tramiteAdopcion.EdadHijoMenor,
                HayChicos = tramiteAdopcion.HayChicos,
                HayMascotas = tramiteAdopcion.HayMascotas,
                HorasSolo = tramiteAdopcion.HorasSolo,
                MotivoAdopcion = tramiteAdopcion.MotivoAdopcion,
                PaseoXMes = tramiteAdopcion.PaseoXMes,
                Lugar = tramiteAdopcion.Lugar,
                PropietarioInquilino = tramiteAdopcion.PropietarioInquilino,
                TramiteId = tramiteAdopcion.TramiteId,
                Vacunados = tramiteAdopcion.Vacunados,
                CabeceraTramiteId = tramiteAdopcion.CabeceraTramiteId
            };
            return Task.FromResult(response);
        }

        public Task<TramiteTransitoResponse> TramiteTransitoResponse(TramiteTransito tramiteTransito)
        {
            var response = new TramiteTransitoResponse
            {
                PropietarioInquilino = tramiteTransito.PropietarioInquilino,
                Cantidadpersonas = tramiteTransito.Cantidadpersonas,
                ChicosYEdad = tramiteTransito.ChicosYEdad,
                DisponibilidadHoraria = tramiteTransito.DisponibilidadHoraria,
                Emergencia = tramiteTransito.Emergencia,
                Expectativa = tramiteTransito.Expectativa,
                ExperienciaDeTransito = tramiteTransito.ExperienciaDeTransito,
                HayMascotas = tramiteTransito.HayMascotas,
                ManejoAnimal = tramiteTransito.ManejoAnimal,
                MedioDeTransporte = tramiteTransito.MedioDeTransporte,
                PoliticaOrganizacion = tramiteTransito.PoliticaOrganizacion,
                RazonInteres = tramiteTransito.RazonInteres,
                Rutina = tramiteTransito.Rutina,
                Seguimiento = tramiteTransito.Seguimiento,
                TiempoDeAcogida = tramiteTransito.TiempoDeAcogida,
                TipoDeEspacio = tramiteTransito.TipoDeEspacio,
                VacunadosCastrados = tramiteTransito.VacunadosCastrados,
                CabeceraTramiteId = tramiteTransito.CabeceraTramiteId
            };
            return Task.FromResult(response);
        }

        public Task<List<TramiteResponse>> GetTramitesAdopcionResponse(List<TramiteAdopcion> tramitesAdopcion)
        {
            throw new NotImplementedException();
        }

        public Task<List<TramiteResponse>> GetTramitesTransitoResponse(List<TramiteTransito> tramitesTransito)
        {
            throw new NotImplementedException();
        }
    }
}
