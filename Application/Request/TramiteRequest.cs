namespace Application.Request
{
    public class TramiteRequest
    {
        public int UsuarioId { get; set; }
        public int TramiteTipoId { get; set; }
        public int AnimalId { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
    }
}
