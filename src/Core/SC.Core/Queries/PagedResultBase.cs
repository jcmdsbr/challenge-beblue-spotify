using System.Collections.Generic;
using System.Linq;

namespace SC.Core.Queries
{
    public class PagedResultBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
    }

    public class PagedResult<T> : PagedResultBase where T : IQueryModel
    {
        public IReadOnlyCollection<T> Results { get; set; }

        public PagedResult(IEnumerable<T> results)
        {
            Results = results.ToList();
        }
    }
}
