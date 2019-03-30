using System;
using System.Collections.Generic;
using System.Linq;
using SC.Domain.ValueObjects;
namespace SC.Domain.Models {
    public class Sale : IEntity<Guid> {
        protected Sale () { }
        private Sale (Cpf customerCpf, List<SaleDetail> details) {
            this.Id = Guid.NewGuid ();
            this.RealizedAt = DateTime.Now;
            this.Details = details;
            this.Price = details.Sum (x => x.Playlist?.Price);
            this.Cashback = details.Sum (x => x.Cashback);
            this.CustomerCpf = customerCpf;
        }

        public static Sale Register (Cpf customerCpf, List<SaleDetail> details) => new Sale (customerCpf, details);
        public Guid Id { get; private set; }
        public DateTime RealizedAt { get; private set; }
        public Amount Price { get; private set; }
        public Amount Cashback { get; private set; }
        public Cpf CustomerCpf { get; private set; }
        public List<SaleDetail> Details { get; private set; }

    }
}