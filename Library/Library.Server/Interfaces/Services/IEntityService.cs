namespace Library.Server.Interfaces.Services
{
    public interface IEntityService<T>
    {
        IQueryable<T> QueryableList { get; }

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

        Task<T> GetByIdAsync(int entityId);
    }
}