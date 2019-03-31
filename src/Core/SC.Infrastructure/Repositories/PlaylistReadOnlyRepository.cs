using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SC.Application.Repositories;
using SC.Domain.Entities;
using SC.Domain.Queries.Models;

namespace SC.Infrastructure.Repositories
{
    public class PlaylistReadOnlyRepository : ReadDbContext<Playlist>, IPlaylistReadOnlyRepository
    {
        public PlaylistReadOnlyRepository(SCContext db) : base(db)
        {
        }

        public  async Task<PlaylistViewQueryModel> GetViewQueryModelById(Guid id)
        {
            return await Query
                .Include(x => x.Category)
                .Where(x => x.Id == id)
                .Select(ProjectToViewQueryModel())
                .FirstOrDefaultAsync();
        }

        private static Expression<Func<Playlist, PlaylistViewQueryModel>> ProjectToViewQueryModel()
        {
            return playlist => 
                new PlaylistViewQueryModel(playlist.Id, 
                    playlist.Price, 
                    playlist.Name,
                    playlist.CategoryId,
                    playlist.Category.Description);
        }
    }
}