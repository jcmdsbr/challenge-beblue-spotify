using SC.Core.Queries;
using SC.Domain.Queries.Models;

namespace SC.Domain.Queries.Playlists
{
    public class GetPlaylistsPagedQuery : IQuery<PlaylistPagedQueryModel>
    {
        public GetPlaylistsPagedQuery()
        {
            CacheToken = $"{nameof(GetPlaylistsPagedQuery)}";
        }

        public string CacheToken { get; }
    }
}
