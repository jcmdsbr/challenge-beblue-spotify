using System;
using SC.Core.Queries;
using SC.Domain.Queries.Models;

namespace SC.Domain.Queries.Playlists
{
    public class GetPlaylistByIdQuery : IQuery<PlaylistViewQueryModel>
    {
        public GetPlaylistByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
