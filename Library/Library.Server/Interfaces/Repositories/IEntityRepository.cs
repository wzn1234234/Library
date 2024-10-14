using Microsoft.EntityFrameworkCore.Metadata;

namespace Library.Server.Interfaces.Repositories
{
    public interface IEntityRepository<T> where T : class
    {
        /// <summary>
        /// Whole list of Entities
        /// </summary>
        IQueryable<T> QueryableList { get; }
        /// <summary>
        /// Add a new entity to the table
        /// <param name="entity"></param>
        /// <param name="cancellation"></param>
        /// </summary>
        Task AddAsync(T entity, CancellationToken cancellation = default);
        /// <summary>
        /// Delete an entity by id
        /// <param name="id"></param>
        /// </summary>
        Task DeleteAsync(object id);
        /// <summary>
        /// Update an entity
        /// <param name="entity"></param>
        /// </summary
        Task UpdateAsync(T entity);
        /// <summary>
        /// Returns the primary key property of an entity
        /// </summary>
        IProperty PrimaryKey { get; }
        /// <summary>
        /// Returns the surrogate key property of an entity with a natural primary key.
        /// Surrogate key propery must be configured with UseSqlServerIdentityColumn annotation.
        /// </summary>
        IProperty SurrogateKey { get; }
        /// <summary>
        /// Returns entity with given primary key valye
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(object id);

    }
}
