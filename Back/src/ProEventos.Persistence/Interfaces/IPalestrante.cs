using ProEventos.Domain;

namespace ProEventos.Persistence.Interfaces
{
    public interface IPalestrante
    {
        Task<IEnumerable<Palestrante>> ObterPalestrantesPorNomeAsync(string nome, bool includeEvento);
        Task<IEnumerable<Palestrante>> ObterPalestrantesAsync(bool includeEvento);
        Task<Palestrante> ObterPalestrantePorIdAsync(int id, bool includeEvento);
    }
}
