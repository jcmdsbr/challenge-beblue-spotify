using System;
using System.Collections.Generic;
using SC.Core.Queries;
using SC.Domain.ValueObjects;

namespace SC.Domain.Queries.Models
{
    public class SaleViewQueryModel : IQueryModel
    {
        public SaleViewQueryModel(DateTime realizedAt, decimal price, decimal cashback, string customerCpf,
            IEnumerable<SaleDetailViewQuerymodel> details, Guid id)
        {
            RealizedAt = realizedAt;
            Price = price;
            Cashback = cashback;
            CustomerCpf = customerCpf;
            Details = details;
            Id = id;
        }

        public DateTime RealizedAt { get; set; }
        public decimal Price { get; set; }
        public decimal Cashback { get; set; }
        public string CustomerCpf { get; set; }
        public IEnumerable<SaleDetailViewQuerymodel> Details { get; set; }
        public Guid Id { get; set; }
    }

    public class SaleDetailViewQuerymodel
    {
        public SaleDetailViewQuerymodel(decimal cashback, string playlist)
        {
            Cashback = cashback;
            Playlist = playlist;
        }

        public decimal Cashback { get; set; }
        public string Playlist { get; set; }
    }
}