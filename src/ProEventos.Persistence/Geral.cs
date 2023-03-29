using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence
{
    public class Geral : IGeral
    {
        private readonly MeuDbContext _Db;

        public Geral(MeuDbContext context)
        {
            _Db = context;
        }

        public async Task adicionar<T>(T entity) where T : class
        {
            _Db.Add(entity);
            await _Db.SaveChangesAsync();
        }

        public async Task Atualizar<T>(T entity) where T : class
        {
            _Db.Update(entity);
            await _Db.SaveChangesAsync();
        }

        public async Task Deletar<T>(T entity) where T : class
        {
            _Db.Remove(entity);
            await _Db.SaveChangesAsync();
        }

        public async Task DeletarRange<T>(T[] entity) where T : class
        {
            _Db.RemoveRange(entity);
            await _Db.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _Db.SaveChangesAsync()) > 0;
        }
    }
}
