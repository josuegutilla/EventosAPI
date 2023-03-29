using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence
{
    public class EventoPersistence : IEvento
    {
        private readonly MeuDbContext _Db;

        public EventoPersistence(MeuDbContext context) //repository VAI NO BANCO
        {
            _Db = context;
        }

        public async Task<IEnumerable<Evento>> ObterEventosAsync(bool includePalestrante = false)
        {
            IQueryable<Evento> query = _Db.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrante)
            {
                query.Include(x => x.PalestrantesEventos)
                    .ThenInclude(x => x.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id);

            return await query.ToListAsync();
        }

        public async Task<Evento> ObterEventoPorIdAsync(int id, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _Db.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrante)
            {
                query = query.Include(x => x.PalestrantesEventos)
                    .ThenInclude(x => x.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id)
                                        .Where(x => x.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Evento>> ObterEventosPorTemaAsync(string tema, bool includePalestrante = false)
        {
            IQueryable<Evento> query = _Db.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if (includePalestrante)
            {
                query = query.Include(x => x.PalestrantesEventos)
                    .ThenInclude(x => x.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id)
                                        .Where(x => x.Tema.ToLower().Contains(tema));

            return await query.ToListAsync();
        }
    }
}
