namespace Application.Response
{
    public class UpdateTramiteResponse
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public GetAllTramiteEstadoResponse EstadoResponse { get; set; }
        public GetAllTramiteTipoResponse TipoResponse { get; set; }
        public int AnimalId { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
    }
}
