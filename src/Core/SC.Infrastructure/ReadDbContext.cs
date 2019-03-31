using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SC.Core.Models;
using SC.Core.Repository;

namespace SC.Infrastructure
{
    public class ReadDbContext<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbSet<TEntity> DbSet;

        public ReadDbContext(SCContext db) => DbSet = db.Set<TEntity>();

        public virtual async Task<TEntity> FindById(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IReadOnlyCollection<TEntity>> List()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }
    }
}