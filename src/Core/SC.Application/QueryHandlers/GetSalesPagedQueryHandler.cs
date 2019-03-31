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
    public class GetSalesPagedQueryHandler : IQueryHandler<GetSalesPagedQuery, SalePagedQueryModel>
    {
        private readonly IDistributedCache _cache;
        private readonly ISaleReadOnlyRepository _query;

        public GetSalesPagedQueryHandler(IDistributedCache cache, ISaleReadOnlyRepository query)
        {
            _cache = cache;
            _query = query;
        }

        public async Task<SalePagedQueryModel> Handle(GetSalesPagedQuery request, CancellationToken cancellationToken)
        {
            var json = await _cache.GetStringAsync(request.CacheToken);

            if (!IsNullOrEmpty(json)) return JsonConvert.DeserializeObject<SalePagedQueryModel>(json);

            var queryModel = await _query.GetPaged(request.Page, request.PageSize, request.DtInitial, request.DtEnd);

            var cacheOptions = new DistributedCacheEntryOptions();

            cacheOptions.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

            _cache.SetString(request.CacheToken, JsonConvert.SerializeObject(queryModel), cacheOptions);

            return queryModel;
        }
    }
}