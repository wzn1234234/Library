using Library.Server.DBContexts;
using Library.Server.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Update;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Library.Server.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T: class
    {
        protected readonly AppDBContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public EntityRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentException(nameof(dbContext));
            _dbSet = _dbContext.Set<T>();
        }

        public virtual IQueryable<T> QueryableList => _dbSet.AsNoTracking();

        public async Task AddAsync(T entity, CancellationToken cancellation = default)
        {
            await _dbSet.AddAsync(entity, cancellation);
        }

        public async Task DeleteAsync(object id)
        {
            var typeInfo = typeof(T).GetTypeInfo();
            var key = _dbContext.Model.FindEntityType(typeInfo).FindPrimaryKey().Properties.FirstOrDefault();
            var property = typeInfo.GetProperty(key?.Name);
            if (property != null)
            {
                var entity = Activator.CreateInstance<T>();
                property.SetValue(entity, id);
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            else
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity != null) _dbSet.Remove(entity);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            if (SurrogateKey != null)
            {
                var idName = SurrogateKey.Name;
                var idValue = entity.GetType().GetProperty(idName).GetValue(entity, null);
                var keyColumnName = _dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Select(x => x.GetColumnName()).FirstOrDefault();
                var keyPropertyName = _dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Select(x => x.Name).Single();

                var keyValue = entity.GetType().GetProperty(keyPropertyName).GetValue(entity, null);

                await UpdateKeyAsync(entity, keyColumnName, idName, keyValue, idValue);
            }

            _dbSet.Update(entity);
        }

        public async Task<int> UpdateKeyAsync(T entity, string keyColumnName, string idName, object keyValue, object idValue)
        {
            var mapping = _dbContext.Model.FindEntityType(typeof(T));
            var tableName = mapping.GetTableName();

            var result = await _dbContext.Database.ExecuteSqlRawAsync(
                $"UPDATE [{tableName}] SET [{keyColumnName}] = @key WHERE [{idName}] = @id;",
                parameters: new object[]
                {
                    new SqlParameter("@key", keyValue),
                    new SqlParameter("@id", idValue)
                }
                );

            if (result <= 0)
                throw new DbUpdateConcurrencyException("", new ReadOnlyCollection<IUpdateEntry>(new List<IUpdateEntry>() { null }));

            return result;
        }

        /// <summary>
        /// Returns the primary key property of an entity
        /// </summary>
        public IProperty PrimaryKey => _dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.Single();
        /// <summary>
        /// Returns the surrogate key property of an entity with a natural primary key.
        /// Surrogate key propery must be configured with UseSqlServerIdentityColumn annotation.
        /// </summary>
        public IProperty SurrogateKey => _dbContext.Model.FindEntityType(typeof(T)).GetProperties().Where(p => !p.IsPrimaryKey() && p.ValueGenerated != null && p.GetValueGenerationStrategy() == SqlServerValueGenerationStrategy.IdentityColumn).FirstOrDefault();
        /// <summary>
        /// Returns entity with given primary key valye
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(object id)
        {
            var entity = await _dbSet.FindAsync(id);

            //as no tracking
            _dbContext.Entry(entity).State = EntityState.Detached;

            return entity;
        }
    }
}
