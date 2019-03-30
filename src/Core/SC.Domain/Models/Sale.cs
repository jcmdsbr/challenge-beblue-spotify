using System;
using System.Collections.Generic;
using System.Linq;
using SC.Domain.ValueObjects;

namespace SC.Domain.Models
{
    public class Sale : IEntity<Guid>
    {
        protected Sale()
        {
        }

        private Sale(Cpf customerCpf, List<SaleDetail> details)
        {
            Id = Guid.NewGuid();
            RealizedAt = DateTime.Now;
            Details = details;
            Price = details.Sum(x => x.Playlist?.Price);
            Cashback = details.Sum(x => x.Cashback);
            CustomerCpf = customerCpf;
        }

        public DateTime RealizedAt { get; }
        public Amount Price { get; }
        public Amount Cashback { get; }
        public Cpf CustomerCpf { get; }
        public List<SaleDetail> Details { get; }
        public Guid Id { get; }

        public static Sale Register(Cpf customerCpf, List<SaleDetail> details)
        {
            return new Sale(customerCpf, details);
        }
    }
}