using System;
using System.Threading.Tasks;
using SC.Domain.Models;

namespace SC.Application.Repository
{
   public interface IWriteOnlyRepository<TEntity> where TEntity : IEntity
    {
        // only allowed find the entity for update or delete
        Task<TEntity> FindAsync(object id);

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(object id);
    }
}
