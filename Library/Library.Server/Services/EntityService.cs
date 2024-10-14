using Library.Server.DBContexts;
using Library.Server.Interfaces.Repositories;
using Library.Server.Interfaces.Services;
using Library.Server.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Server.Services
{
    public class EntityService<T> : IEntityService<T> where T : class
    {
        protected readonly AppDBContext _DbContext;
        private Dictionary<Type, object> _repositories;
        public EntityService(AppDBContext DbContext)
        {
            _DbContext = DbContext;
        }

        public virtual IQueryable<T> QueryableList => GetRepository<T>().QueryableList ?? (new List<T>() { }).AsQueryable<T>();

        public virtual async Task<T> GetByIdAsync(int entityId)
        {
            return await GetRepository<T>().GetByIdAsync(entityId);
        }

        public virtual async Task AddAsync(T entity)
        {
            await GetRepository<T>().AddAsync(entity);
            await _DbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await GetRepository<T>().UpdateAsync(entity);
            await _DbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            await GetRepository<T>().DeleteAsync(id);
            await _DbContext.SaveChangesAsync();
        }

        public IEntityRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new EntityRepository<TEntity>(_DbContext);
            return (IEntityRepository<TEntity>)_repositories[type];
        }
    }
}
