using System;
using System.Collections.Generic;
using System.Linq;
using SC.Core.Models;
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

        public DateTime RealizedAt { get; private set; }
        public Amount Price { get; private set; }
        public Amount Cashback { get; private set; }
        public Cpf CustomerCpf { get; private set; }
        public List<SaleDetail> Details { get; private set; }
        public Guid Id { get; private set; }

        public static Sale Register(Cpf customerCpf, List<SaleDetail> details)
        {
            return new Sale(customerCpf, details);
        }
    }
}