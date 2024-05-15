using Application.Interfaces.IMappers;
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
                AnimalId = tramite.AnimalId,
                Comentario = tramite.Comentario,
                EstadoResponse = await _estadoMapper.TramiteEstadoResponse(tramite.TramiteEstado),
                TipoResponse = await _tipoMapper.TramiteTipoResponse(tramite.TramiteTipo),
                FechaFinalizacion = tramite.FechaFinalizacion,
                FechaInicio = tramite.FechaInicio,
                UsuarioId = tramite.UsuarioId,
            };
            return response;
        }

        public async Task<UpdateTramiteResponse> UpdateTramiteResponse(Tramite tramite)
        {
            var response = new UpdateTramiteResponse
            {

                AnimalId = tramite.AnimalId,
                Comentario = tramite.Comentario,
                Id = tramite.Id,
                EstadoResponse = await _estadoMapper.TramiteEstadoResponse(tramite.TramiteEstado),
                TipoResponse = await _tipoMapper.TramiteTipoResponse(tramite.TramiteTipo),
                FechaFinalizacion = tramite.FechaFinalizacion,
                FechaInicio = tramite.FechaInicio,
                UsuarioId = tramite.UsuarioId,
            };
            return response;
        }
    }
}
