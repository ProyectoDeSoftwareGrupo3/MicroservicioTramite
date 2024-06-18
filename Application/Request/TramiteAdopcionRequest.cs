namespace Application.Request
{
    public class TramiteAdopcionRequest
    {
        //Cabecera
        public Guid UsuarioId { get; set; }
        public Guid UsuarioAdoptanteId { get; set; }
        public int AnimalId { get; set; }
        //Cuerpo
        public int CantidadPersonas { get; set; }
        public bool HayChicos { get; set; }
        public int? EdadHijoMenor { get; set; }
        public bool HayMascotas { get; set; }
        public bool Vacunados { get; set; }
        public bool Castrados { get; set; }
        public bool PropietarioInquilino { get; set; }
        public string AireLibre { get; set; }
        public string MotivoAdopcion { get; set; }
        public int HorasSolo { get; set; }
        public int PaseoXMes { get; set; }
    }
}
