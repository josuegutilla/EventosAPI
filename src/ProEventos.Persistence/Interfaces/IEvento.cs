using ProEventos.Domain;

namespace ProEventos.Persistence.Interfaces
{
    public interface IEvento
    {
        Task<IEnumerable<Evento>> ObterEventosAsync(bool includePalestrante = false);
        Task<IEnumerable<Evento>> ObterEventosPorTemaAsync(string tema, bool includePalestrante = false);
        Task<Evento> ObterEventoPorIdAsync(int id, bool includePalestrante = false);
    }
}
