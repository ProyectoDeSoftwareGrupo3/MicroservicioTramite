namespace Application.Response
{
    public class TramiteResponse
    {
        public int Id { get; set; }
        public Guid UsuarioId { get; set; }
        public int AnimalId { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }

        public GetAllTramiteEstadoResponse EstadoResponse { get; set; }
        public GetAllTramiteTipoResponse TipoResponse { get; set; }
    }
}
