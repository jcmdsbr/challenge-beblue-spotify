using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using SC.Application.Repositories;
using SC.Core.Queries;
using SC.Domain.Queries.Models;
using SC.Domain.Queries.Playlists;

namespace SC.Application.QueryHandlers
{
    public class GetPlaylistsPagedQueryHandler : IQueryHandler<GetPlaylistsPagedQuery, PlaylistPagedQueryModel>
    {
        private readonly IDistributedCache _cache;
        private readonly IPlaylistReadOnlyRepository _query;

        public GetPlaylistsPagedQueryHandler(IDistributedCache cache, IPlaylistReadOnlyRepository query)
        {
            _cache = cache;
            _query = query;
        }

        public Task<PlaylistPagedQueryModel> Handle(GetPlaylistsPagedQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}