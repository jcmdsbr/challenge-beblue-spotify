using System;
using System.Threading.Tasks;
using SC.Core.Repository;
using SC.Domain.Entities;
using SC.Domain.Queries.Models;

namespace SC.Application.Repositories
{
    public interface ISaleReadOnlyRepository : IReadOnlyRepository<Sale>
    {
        Task<SalePagedQueryModel> GetPaged(int page, int pageSize, DateTime? dtInitial, DateTime? dtEnd);
        Task<SaleViewQueryModel> GetViewQueryModelById(Guid id);
    }
}