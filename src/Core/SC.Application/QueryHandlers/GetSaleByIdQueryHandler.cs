using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using SC.Application.Repositories;
using SC.Core.Queries;
using SC.Domain.Queries.Models;
using SC.Domain.Queries.Sales;
using static System.String;

namespace SC.Application.QueryHandlers
{
    public class GetSaleByIdQueryHandler : IQueryHandler<GetSaleByIdQuery, SaleViewQueryModel>
    {
        private readonly IDistributedCache _cache;
        private readonly ISaleReadOnlyRepository _query;

        public GetSaleByIdQueryHandler(IDistributedCache cache, ISaleReadOnlyRepository query)
        {
            _cache = cache;
            _query = query;
        }

        public async Task<SaleViewQueryModel> Handle(GetSaleByIdQuery request, CancellationToken cancellationToken)
        {
            var json = await _cache.GetStringAsync(request.CacheToken);

            if (!IsNullOrEmpty(json)) return JsonConvert.DeserializeObject<SaleViewQueryModel>(json);

            var queryModel = await _query.GetViewQueryModelById(request.Id);

            var cacheOptions = new DistributedCacheEntryOptions();

            cacheOptions.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

            _cache.SetString(request.CacheToken, JsonConvert.SerializeObject(queryModel), cacheOptions);

            return queryModel;
        }
    }
}