namespace Domain.Entities
{
    public class Tramite
    {
        public int Id { get; set; }
        public Guid UsuarioId { get; set; }
        public int UsuarioAdoptanteId {  get; set; }
        public bool Chicos { get; set; }
        public int Cantidadpersonas {  get; set; }
        public bool HayAnimales {  get; set; }
        public bool Vacunados {  get; set; }
        public bool Castrados {  get; set; }
        public string LugarAdopcion {  get; set; }
        public bool PropietarioInquilino { get; set; }
        public string AireLibre {  get; set; }
        public string MotivoAdopcion {get; set; }
        public int HorasSolo {  get; set; }
        public int PaseoMes {  get; set; }
        public int TramiteTipoId { get; set; }
        public int TramiteEstadoId { get; set; }
        public int AnimalId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }

        public TramiteEstado TramiteEstado { get; set; }
        //poner default en revision
        public TramiteTipo TramiteTipo { get; set; }

    }
}
