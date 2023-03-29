namespace ProEventos.Domain;

public class Evento
{
    public int Id { get; set; }
    public string Local { get; set; }
    public string DataEvento { get; set; }
    public string Tema { get; set; }
    public int QtdPessoas { get; set; }
    public string Lote { get; set; }
    public string ImagemURl { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public IEnumerable<Lote> Lotes { get; set; } //associação
    public IEnumerable<RedeSocial> RedesSociais { get; set; } //associação
    public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; } //associação
}