using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SC.Core.Repository;
using SC.Domain.Entities;

namespace SC.Application.Repositories
{
    public interface IPlaylistWriteOnlyRepository : IWriteOnlyRepository<Playlist>
    {
        Task<List<Playlist>> ListBy(IReadOnlyCollection<Guid> requestPlaylists);
    }
}
