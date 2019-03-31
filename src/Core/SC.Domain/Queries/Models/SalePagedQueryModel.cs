using System.Collections.Generic;
using SC.Core.Queries;

namespace SC.Domain.Queries.Models
{
    public class SalePagedQueryModel : PagedResult<SaleViewQueryModel>, IQueryModel
    {
        public SalePagedQueryModel(IEnumerable<SaleViewQueryModel> results) : base(results)
        {
        }
    }
}