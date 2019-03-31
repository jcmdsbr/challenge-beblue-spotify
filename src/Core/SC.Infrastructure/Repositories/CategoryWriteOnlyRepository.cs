using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return await DbSet.AnyAsync(x => !categoriesPlaylist.Contains(x.Id));
        }

        private IQueryable<int> GetCategoriesPlaylist()
        {
            return _playlists.AsNoTracking().Select(x => x.CategoryId).Distinct();
        }

        public async Task<Stack<Category>> GetCategoriesWithoutPlaylist()
        {
            var categoriesPlaylist = GetCategoriesPlaylist();
            return new Stack<Category>(await DbSet.Where(x => !categoriesPlaylist.Contains(x.Id)).ToListAsync());
        }
    }
}
