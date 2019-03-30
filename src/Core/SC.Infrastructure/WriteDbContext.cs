using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SC.Application.Repository;

namespace SC.Infrastructure
{
    public class WriteDbContext<TEntity> : IWriteOnlyRepository<TEntity> where TEntity : class, SC.Domain.Models.IEntity
    {

        protected readonly DbSet<TEntity> DbSet;

        public WriteDbContext(SCContext db)
        {
            DbSet = db.Set<TEntity>();
        }

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