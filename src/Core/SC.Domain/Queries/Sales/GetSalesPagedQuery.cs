using System;
using SC.Core.Queries;
using SC.Domain.Queries.Models;

namespace SC.Domain.Queries.Sales
{
    public class GetSalesPagedQuery : IQuery<SalePagedQueryModel>
    {
        public GetSalesPagedQuery(int page, int pageSize, DateTime? dtInitial, DateTime? dtEnd)
        {
            Page = page;
            PageSize = pageSize;
            DtInitial = dtInitial;
            DtEnd = dtEnd;
            CacheToken = $"{nameof(GetSalesPagedQuery)}?{page}&{pageSize}&{dtInitial}&{dtEnd}";
        }
        public int Page { get; }
        public int PageSize { get; }
        public DateTime? DtInitial{ get; }
        public DateTime? DtEnd { get; }
        public string CacheToken { get; }
    }
}
