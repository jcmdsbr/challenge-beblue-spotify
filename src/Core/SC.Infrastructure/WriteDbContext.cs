using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SC.Core.Models;
using SC.Core.Repository;
using SC.Domain.Models;

namespace SC.Infrastructure
{
    public class WriteDbContext<TEntity> : IWriteOnlyRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbSet<TEntity> DbSet;

        public WriteDbContext(SCContext db) => DbSet = db.Set<TEntity>();

        public virtual async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public virtual async Task DeleteAsync(object id)
        {
            var entity = await DbSet.FindAsync(id);
            DbSet.Remove(entity);
        }

        public virtual async Task<TEntity> FindAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            var entry = await DbSet.AddAsync(entity);
            entry.State = EntityState.Modified;
        }
    }
}