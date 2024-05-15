namespace Domain.Entities
{
    public class TramiteEstado
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public List<Tramite> Tramites { get; set; }
    }
}
