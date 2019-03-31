using System.Collections.Generic;
using SC.Core.Queries;

namespace SC.Domain.Queries.Models
{
    public class PlaylistPagedQueryModel : PagedResult<PlaylistViewQueryModel>, IQueryModel
    {
        public PlaylistPagedQueryModel(IEnumerable<PlaylistViewQueryModel> results) : base(results)
        {
        }
    }
}