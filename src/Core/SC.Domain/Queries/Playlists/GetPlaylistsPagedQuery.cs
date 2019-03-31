using SC.Core.Queries;
using SC.Domain.Queries.Models;

namespace SC.Domain.Queries.Playlists
{
    public class GetPlaylistsPagedQuery : IQuery<PlaylistPagedQueryModel>
    {
        public GetPlaylistsPagedQuery(int page, int pageSize, string genre)
        {
            Page = page;
            PageSize = pageSize;
            Genre = genre;
            CacheToken = $"{nameof(GetPlaylistsPagedQuery)}?{page}&{pageSize}&{genre}";
        }

        public int Page { get; }
        public int PageSize { get; }
        public string Genre { get; }
        public string CacheToken { get; }
    }
}
