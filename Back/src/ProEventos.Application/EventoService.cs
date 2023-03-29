using ProEventos.Application.Interfaces;
using ProEventos.Domain;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeral _geral;
        private readonly IEvento _evento;

        public EventoService(IGeral geral, IEvento evento)
        {
            _geral = geral;
            _evento = evento;
        }

        public async Task<Evento> AdicionarEventos(Evento evento)
        {
            try
            {
                await _geral.adicionar<Evento>(evento);
                if (await _geral.SaveChangesAsync())
                {
                    return await _evento.ObterEventoPorIdAsync(evento.Id, false);
                }

                return null;

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<Evento> AtualizarEventos(int id, Evento evento)
        {
            try
            {
                Evento eventos = await _evento.ObterEventoPorIdAsync(id, false);
                if (eventos == null) return null;

                evento.Id = eventos.Id;

                await _geral.Atualizar<Evento>(eventos);
                if (await _geral.SaveChangesAsync())
                {
                    return await _evento.ObterEventoPorIdAsync(evento.Id, false);
                }

                return null;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<bool> DeletarEventos(int id)
        {
            try
            {
                Evento evento = await _evento.ObterEventoPorIdAsync(id);
                if(evento == null) throw new Exception("Evento deletar não encontrado.");

                await _geral.Deletar<Evento>(evento);

                return await _geral.SaveChangesAsync();

            }
            catch(Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<IEnumerable<Evento>> ObterEventosAsync(bool includePalestrante = false)
        {
            try
            {
                var eventos = await _evento.ObterEventosAsync(includePalestrante);

                if (eventos == null) return null;

                return eventos;

            }
            catch(Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        public async Task<IEnumerable<Evento>> ObterEventosPorTemaAsync(string tema, bool includePalestrante = false)
        {
            try
            {
                var eventos = await _evento.ObterEventosPorTemaAsync(tema, includePalestrante);

                if (eventos == null) return null;

                return eventos;

            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
        
        public async Task<Evento> ObterEventoPorIdAsync(int id, bool includePalestrante = false)
        {
            try
            {
                var evento = await _evento.ObterEventoPorIdAsync(id, includePalestrante);

                if(evento == null) return null;

                return evento;

            }
            catch(Exception err)
            {
                throw new Exception(err.Message);  
            }
        }
    }
}
