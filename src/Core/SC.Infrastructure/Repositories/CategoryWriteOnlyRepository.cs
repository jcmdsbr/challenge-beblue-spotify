using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SC.Application.Repositories;
using SC.Domain.Entities;

namespace SC.Infrastructure.Repositories
{
    public class CategoryWriteOnlyRepository : WriteDbContext<Category>, ICategoryWriteOnlyRepository
    {
        private readonly DbSet<Playlist> _playlists;

        public CategoryWriteOnlyRepository(SCContext db) : base(db)
        {
            _playlists = db.Playlists;
        }

        public async Task<bool> CheckMigratePlaylistCategory()
        {
            var categoriesPlaylist = GetCategoriesPlaylist();
            return await Session.AnyAsync(x => !categoriesPlaylist.Contains(x.Id));
        }

        public async Task<Stack<Category>> GetCategoriesWithoutPlaylist()
        {
            var categoriesPlaylist = GetCategoriesPlaylist();
            return new Stack<Category>(await Session.Where(x => !categoriesPlaylist.Contains(x.Id)).ToListAsync());
        }

        private IQueryable<int> GetCategoriesPlaylist()
        {
            return _playlists.AsNoTracking().Select(x => x.CategoryId).Distinct();
        }
    }
}