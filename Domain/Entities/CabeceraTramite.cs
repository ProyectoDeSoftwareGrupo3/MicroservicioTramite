namespace Domain.Entities
{
    public class CabeceraTramite
    {
        public int Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid UsuarioSolicitanteId { get; set; }        
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }


        public TramiteEstado Estado { get; set; }
        public int EstadoId { get; set; }

        public TramiteAdopcion TramiteAdopcion { get; set; }
        public TramiteTransito TramiteTransito { get; set; }        

    }
}