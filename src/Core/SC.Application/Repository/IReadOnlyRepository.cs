using System.Collections.Generic;
using System.Threading.Tasks;

namespace SC.Application.Repository
{
    public interface IReadOnlyRepository<TEntity>
    {
        Task<TEntity> FindById(object id);
        Task<IReadOnlyCollection<TEntity>> List();
    }
}