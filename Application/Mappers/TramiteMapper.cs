﻿using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class TramiteMapper : ITramiteMapper
    {
        private readonly ITramiteTipoMapper _tipoMapper;
        private readonly ITramiteEstadoMapper _estadoMapper;
        public TramiteMapper(ITramiteEstadoMapper estadoMapper, ITramiteTipoMapper tipoMapper)
        {
            _estadoMapper = estadoMapper;
            _tipoMapper = tipoMapper;
        }

        public async Task<TramiteResponse> TramiteResponse(Tramite tramite)
        {
            var response = new TramiteResponse
            {
                UsuarioId = tramite.UsuarioId,
                UsuarioAdoptanteId = tramite.UsuarioAdoptanteId,
                AnimalId = tramite.AnimalId,
                HayChicos=tramite.Chicos,
                Cantidadpersonas = tramite.Cantidadpersonas,
                HayAnimales = tramite.HayAnimales,
                Vacunados= tramite.Vacunados,
                Castrados=tramite.Castrados,
                LugarAdopcion=tramite.LugarAdopcion,
                PropietarioOInquilino=tramite.PropietarioInquilino,
                AireLibre=tramite.AireLibre,
                MotivoAdopcion=tramite.MotivoAdopcion,
                HorasSolo=tramite.HorasSolo,
                PaseoxMes=tramite.PaseoMes,
                FechaInicio= tramite.FechaInicio,
                EstadoResponse = await _estadoMapper.TramiteEstadoResponse(tramite.TramiteEstado),
                TipoResponse = await _tipoMapper.TramiteTipoResponse(tramite.TramiteTipo),
                
            };
            return response;
        }

        public async Task<UpdateTramiteResponse> UpdateTramiteResponse(Tramite tramite)
        {
            var response = new UpdateTramiteResponse
            {
                Id = tramite.Id,
                UsuarioId = tramite.UsuarioId,
                UsuarioAdoptanteId = tramite.UsuarioAdoptanteId,
                AnimalId = tramite.AnimalId,
                HayChicos = tramite.Chicos,
                Cantidadpersonas=tramite.Cantidadpersonas,
                HayAnimales=tramite.HayAnimales,
                Vacunados=tramite.Vacunados,
                Castrados=tramite.Castrados,
                LugarAdopcion=tramite.LugarAdopcion,
                PropietarioOInquilino=tramite.PropietarioInquilino,
                AireLibre=tramite.AireLibre,
                MotivoAdopcion=tramite.MotivoAdopcion,
                HorasSolo=tramite.HorasSolo,
                PaseoxMes=tramite.PaseoMes,
                TramiteTipoId=tramite.TramiteTipoId,
                TramiteEstadoId=tramite.TramiteEstadoId,
                FechaFinalizacion = tramite.FechaFinalizacion,
                FechaInicio = tramite.FechaInicio,
                EstadoResponse = await _estadoMapper.TramiteEstadoResponse(tramite.TramiteEstado),
                TipoResponse = await _tipoMapper.TramiteTipoResponse(tramite.TramiteTipo),
            };
            return response;
        }
    }
}
