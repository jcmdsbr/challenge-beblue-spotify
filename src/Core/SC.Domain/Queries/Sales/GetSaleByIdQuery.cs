using System;
using SC.Core.Queries;
using SC.Domain.Queries.Models;

namespace SC.Domain.Queries.Sales
{
    public class GetSaleByIdQuery : IQuery<SaleViewQueryModel>
    {
        public GetSaleByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
