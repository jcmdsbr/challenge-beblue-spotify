using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using SC.Application.Repositories;
using SC.Core.Queries;
using SC.Domain.Queries.Models;
using SC.Domain.Queries.Sales;

namespace SC.Application.QueryHandlers
{
    public class GetSalesPagedQueryHandler : IQueryHandler<GetSalesPagedQuery, SalePagedQueryModel>
    {
        private readonly IDistributedCache _cache;
        private readonly ISaleReadOnlyRepository _query;

        public GetSalesPagedQueryHandler(IDistributedCache cache, ISaleReadOnlyRepository query)
        {
            _cache = cache;
            _query = query;
        }

        public Task<SalePagedQueryModel> Handle(GetSalesPagedQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}