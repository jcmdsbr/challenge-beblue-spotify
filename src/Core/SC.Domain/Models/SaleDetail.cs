using System;
using SC.Domain.ValueObjects;

namespace SC.Domain.Models
{
    public class SaleDetail
    {
        public Guid SaleId { get; private set; }
        public Guid PlaylistId { get; private set; }
        public Amount Cashback { get; private set; }
    }
}