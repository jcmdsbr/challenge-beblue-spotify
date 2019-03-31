using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using SC.Application.Repositories;
using SC.Core.Queries;
using SC.Core.Repository;
using SC.Domain.Entities;
using SC.Domain.Queries.Models;
using SC.Domain.Queries.Playlists;

using static System.String;

namespace SC.Application.QueryHandlers
{
    public class GetPlaylistByIdQueryHandler : IQueryHandler<GetPlaylistByIdQuery, PlaylistViewQueryModel>
    {
        private readonly IDistributedCache _cache;
        private readonly IPlaylistReadOnlyRepository _query;

        public GetPlaylistByIdQueryHandler(IDistributedCache cache, IPlaylistReadOnlyRepository query)
        {
            _cache = cache;
            _query = query;
        }

        public async Task<PlaylistViewQueryModel> Handle(GetPlaylistByIdQuery request,
            CancellationToken cancellationToken)
        {
            var json = await _cache.GetStringAsync(request.CacheToken);

            if (!IsNullOrEmpty(json)) return JsonConvert.DeserializeObject<PlaylistViewQueryModel>(json);

            var queryModel = await _query.GetViewQueryModelById(request.Id);

            var cacheOptions = new DistributedCacheEntryOptions();

            cacheOptions.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

            _cache.SetString(request.CacheToken, JsonConvert.SerializeObject(queryModel), cacheOptions);

            return queryModel;
        }
    }
}