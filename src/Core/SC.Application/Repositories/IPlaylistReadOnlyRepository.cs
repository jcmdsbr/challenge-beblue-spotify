using System;
using System.Threading.Tasks;
using SC.Core.Repository;
using SC.Domain.Entities;
using SC.Domain.Queries.Models;

namespace SC.Application.Repositories
{
    public interface IPlaylistReadOnlyRepository : IReadOnlyRepository<Playlist>
    {
        Task<PlaylistViewQueryModel> GetViewQueryModelById(Guid id);
    }
}