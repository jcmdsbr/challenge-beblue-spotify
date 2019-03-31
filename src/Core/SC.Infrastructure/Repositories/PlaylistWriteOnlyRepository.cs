using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SC.Application.Repositories;
using SC.Domain.Entities;

namespace SC.Infrastructure.Repositories
{
    public class PlaylistWriteOnlyRepository : WriteDbContext<Playlist>, IPlaylistWriteOnlyRepository
    {
        public PlaylistWriteOnlyRepository(SCContext db) : base(db)
        {
        }

        public async Task<List<Playlist>> ListBy(IReadOnlyCollection<Guid> requestPlaylists)
        {
            return await DbSet.Where(x => requestPlaylists.Contains(x.Id)).ToListAsync();
        }
    }
}
