using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SC.Core.Entities;
using SC.Core.Repository;

namespace SC.Infrastructure
{
    public class WriteDbContext<TEntity> : IWriteOnlyRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbSet<TEntity> Session;

        public WriteDbContext(SCContext db) => Session = db.Set<TEntity>();

        public virtual async Task AddAsync(TEntity entity)
        {
            await Session.AddAsync(entity);
        }

        public virtual async Task DeleteAsync(object id)
        {
            var entity = await Session.FindAsync(id);
            Session.Remove(entity);
        }

        public virtual async Task<TEntity> FindAsync(object id)
        {
            return await Session.FindAsync(id);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            var entry = await Session.AddAsync(entity);
            entry.State = EntityState.Modified;
        }
    }
}