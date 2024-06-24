using Domain.Models;

namespace Application.Response
{
    public class TramiteResponse
    {
        public int Id { get; set; }
        public Guid UsuarioId { get; set; }
        public GetUserResponse UsuarioReceptor { get; set; }    
        public Guid UsuarioSolicitanteId { get; set; }
        public GetUserResponse UsuarioRemitente { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }        
        public GetAllTramiteEstadoResponse EstadoResponse { get; set; }
        public TramiteTransitoResponse TransitoResponse { get; set; }
        public TramiteAdopcionResponse AdopcionResponse { get; set;}       
    }
}
