namespace Application.Response
{
    public class TramiteResponse
    {
        public int Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid UsuarioAdoptanteId { get; set; }
        public int AnimalId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }

        public TramiteAdopcionResponse? AdopcionResponse { get; set; } = null;
        public TramiteTransitoResponse? TransitoResponse { get; set; } = null;
        public GetAllTramiteEstadoResponse EstadoResponse { get; set; }


    }
}
