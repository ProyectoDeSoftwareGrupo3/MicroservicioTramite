namespace Application.Request
{
    public class UpdateTramiteRequest
    {
        public int Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid UsuarioAdoptanteId { get; set; }
        public int AnimalId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int EstadoId { get; set; }

        public Guid? TramiteAdopcionId { get; set; }
        public Guid? TramiteTransitoId { get; set; }
    }
}
