using SC.Core.Queries;
using SC.Domain.Queries.Models;

namespace SC.Domain.Queries.Sales
{
    public class GetSalesPagedQuery : IQuery<SalePagedQueryModel>
    {
        public GetSalesPagedQuery()
        {
            CacheToken = $"{nameof(GetSalesPagedQuery)}";
        }
        public string CacheToken { get; }
    }
}
