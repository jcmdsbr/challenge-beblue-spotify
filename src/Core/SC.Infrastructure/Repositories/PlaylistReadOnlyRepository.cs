using System;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SC.Application.Repositories;
using SC.Domain.Entities;
using SC.Domain.Queries.Models;
using static System.String;
namespace SC.Infrastructure.Repositories
{
    public class PlaylistReadOnlyRepository : ReadDbContext<Playlist>, IPlaylistReadOnlyRepository
    {
        public PlaylistReadOnlyRepository(SCContext db) : base(db)
        {
        }

        public async Task<PlaylistViewQueryModel> GetViewQueryModelById(Guid id)
        {
            return await Query
                .Include(x => x.Category)
                .Where(x => x.Id == id)
                .Select(ProjectToViewQueryModel())
                .FirstOrDefaultAsync();
        }

        public async Task<PlaylistPagedQueryModel> GetPaged(int page, int pageSize, string genre)
        {
            var skip = (page - 1) * pageSize;

            var query = Query
                .Include(x => x.Category)
                .OrderBy(x => x.Name)
                .Where(x => IsNullOrEmpty(genre) || x.Category.Description.ToUpper().Equals(genre.ToUpper()))
                .Skip(skip).Take(pageSize).Select(ProjectToViewQueryModel());


            var playlist = await query.ToListAsync();

            var result = new PlaylistPagedQueryModel(playlist)
            {
                CurrentPage = page,
                PageSize = pageSize,
            };

            result.RowCount = await Query.CountAsync();
            result.PageCount = (int)Math.Ceiling((double)result.RowCount / pageSize);

            return result;
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