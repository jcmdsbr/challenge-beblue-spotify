using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SC.Core.Entities;
using SC.Core.Repository;

namespace SC.Infrastructure
{
    public class ReadDbContext<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbSet<TEntity> Query;

        public ReadDbContext(SCContext db) => Query = db.Set<TEntity>();

        public virtual async Task<TEntity> GetViewQueryModelById(object id)
        {
            return await Query.FindAsync(id);
        }

        public virtual async Task<IReadOnlyCollection<TEntity>> List()
        {
            return await Query.AsNoTracking().ToListAsync();
        }
    }
}