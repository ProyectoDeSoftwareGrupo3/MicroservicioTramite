namespace Application.Response
{
    public class TramiteResponse
    {
        public int Id { get; set; }
        public Guid UsuarioId { get; set; }
        public int UsuarioAdoptanteId { get; set; }
        public int AnimalId { get; set; }
        public bool HayChicos { get; set; }
        public int EdadHijoMenor {  get; set; }
        public int Cantidadpersonas { get; set; }
        public bool HayAnimales { get; set; }
        public bool Vacunados { get; set; }
        public bool Castrados { get; set; }
        public string LugarAdopcion { get; set; }
        public bool PropietarioOInquilino { get; set; }
        public string AireLibre { get; set; }
        public string MotivoAdopcion { get; set; }
        public int HorasSolo { get; set; }
        public int PaseoxMes { get; set; }
        public DateTime FechaInicio { get; set; }
        public GetAllTramiteEstadoResponse EstadoResponse { get; set; }
        public GetAllTramiteTipoResponse TipoResponse { get; set; }
    }
}
