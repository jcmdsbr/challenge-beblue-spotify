using System.Threading.Tasks;
using SC.Core.Models;

namespace SC.Core.Repository
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