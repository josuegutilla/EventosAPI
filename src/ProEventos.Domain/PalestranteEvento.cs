namespace ProEventos.Domain
{
    public class PalestranteEvento
    {
        public int PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; } //associação
        public int EventoId { get; set; }
        public Evento Evento { get; set; } //associação
    }
}
