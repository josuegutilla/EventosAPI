using ProEventos.Domain;

namespace ProEventos.Application.Interfaces
{
    public interface IEventoService
    {
        Task<Evento> AdicionarEventos (Evento evento);
        Task<Evento> AtualizarEventos (int id, Evento evento);
        Task<bool> DeletarEventos(int id);
        Task<IEnumerable<Evento>> ObterEventosAsync(bool includePalestrante = false);
        Task<IEnumerable<Evento>> ObterEventosPorTemaAsync(string tema, bool includePalestrante = false);
        Task<Evento> ObterEventoPorIdAsync(int id, bool includePalestrante = false);
    }
}
