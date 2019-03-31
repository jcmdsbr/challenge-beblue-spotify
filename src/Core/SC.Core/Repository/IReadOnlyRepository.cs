using System.Collections.Generic;
using System.Threading.Tasks;

namespace SC.Core.Repository
{
    public interface IReadOnlyRepository<TEntity>
    {
        Task<TEntity> GetViewQueryModelById(object id);
        Task<IReadOnlyCollection<TEntity>> List();
    }
}