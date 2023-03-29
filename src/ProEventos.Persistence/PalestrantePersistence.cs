using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence
{
    public class PalestrantePersistence : IPalestrante
    {
        private readonly MeuDbContext _Db;

        public PalestrantePersistence(MeuDbContext context)
        {
            _Db = context;
        }

        public async Task<Palestrante> ObterPalestrantePorIdAsync(int id, bool includeEvento = false)
        {
            IQueryable<Palestrante> query = _Db.Palestrantes.Include(x => x.RedesSociais);

            if(includeEvento)
            {
                query = query.Include(x => x.PalestrantesEventos).ThenInclude(x => x.Evento);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id).Where(x => x.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Palestrante>> ObterPalestrantesAsync(bool includeEvento = false)
        {
            IQueryable<Palestrante> query = _Db.Palestrantes.Include(x => x.RedesSociais);

            if(includeEvento)
            {
                query = query.Include(x => x.PalestrantesEventos)
                    .ThenInclude(x => x.Evento);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Palestrante>> ObterPalestrantesPorNomeAsync(string nome, bool includeEvento = false) 
        {
            IQueryable<Palestrante> query = _Db.Palestrantes.Include(x => x.RedesSociais);

            if (includeEvento)
            {
                query = query.Include(x => x.PalestrantesEventos)
                    .ThenInclude(x => x.Evento);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id).Where(x => x.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToListAsync();
        }
    }
}
