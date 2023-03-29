namespace ProEventos.Persistence.Interfaces
{
    public interface IGeral
    {
        Task adicionar<T>(T entity) where T : class;
        Task Atualizar<T>(T entity) where T : class;
        Task Deletar<T>(T entity) where T : class;
        Task DeletarRange<T>(T[] entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}
