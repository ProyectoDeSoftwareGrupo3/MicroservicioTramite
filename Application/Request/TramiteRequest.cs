namespace Application.Request
{
    public class TramiteRequest
    {
        public Guid UsuarioId { get; set; }
        public int UsuarioAdoptante { get; set; }
        public int TramiteTipoId { get; set; }
        public int AnimalId { get; set; }
        public bool HayChicos { get; set; }
        public int EdadHijoMenor { get; set; }
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

    }
}
