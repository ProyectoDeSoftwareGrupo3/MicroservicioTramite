using Domain.Entities;
using Domain.Models;

namespace Domain.Dtos;

public class CabeceraTramiteDto
{
    public int Id { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid UsuarioSolicitanteId { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFinal { get; set; }
    public string TipoDeTramite { get; set; }


    public TramiteEstado Estado { get; set; }
    public int EstadoId { get; set; }

    public TramiteAdopcion TramiteAdopcion { get; set; }
    public TramiteTransito TramiteTransito { get; set; }
    public GetAnimalResponse Animal { get; set; }

    public CabeceraTramiteDto(CabeceraTramite tramite)
    {
        Id = tramite.Id;
        UsuarioId = tramite.UsuarioId;
        UsuarioSolicitanteId = tramite.UsuarioSolicitanteId;             
        FechaInicio = tramite.FechaInicio;
        FechaFinal = tramite.FechaFinal;
        Estado = tramite.Estado;
        EstadoId = tramite.EstadoId;
        TramiteAdopcion = tramite.TramiteAdopcion;
        TramiteTransito = tramite.TramiteTransito;
    }
}
