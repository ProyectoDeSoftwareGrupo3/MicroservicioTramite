namespace Application.Request
{
    public class UpdateTramiteRequest
    {
        public int Id { get; set; }
        public Guid UsuarioId { get; set; }
        public int UsuarioAdoptanteId { get; set; }
        public int AnimalId { get; set; }
        public bool HayChicos { get; set; }
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
        public int TramiteTipoId { get; set; }
        public int TramiteEstadoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
    }
}
