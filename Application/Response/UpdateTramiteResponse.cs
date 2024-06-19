namespace Application.Response
{
    public class UpdateTramiteResponse
    {
        public int Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid UsuarioSolicitanteId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }

        public GetAllTramiteEstadoResponse EstadoResponse { get; set; }


    }
}
