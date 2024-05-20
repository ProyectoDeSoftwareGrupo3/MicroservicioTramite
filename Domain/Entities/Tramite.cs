namespace Domain.Entities
{
    public class Tramite
    {
        public int Id { get; set; }
        public Guid UsuarioId { get; set; }
        public int TramiteTipoId { get; set; }
        public int TramiteEstadoId { get; set; }
        public int AnimalId { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }

        public TramiteEstado TramiteEstado { get; set; }
        //poner default en revision
        public TramiteTipo TramiteTipo { get; set; }

    }
}
