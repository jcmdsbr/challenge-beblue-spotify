using System.Collections.Generic;
using System.Threading.Tasks;
using SC.Core.Repository;
using SC.Domain.Models;

namespace SC.Application.Repositories
{
    public interface ICategoryWriteOnlyRepository : IWriteOnlyRepository<Category>
    {
        Task<bool> CheckMigratePlaylistCategory();
        Task<Stack<Category>> GetCategoriesWithoutPlaylist();
    }
}
