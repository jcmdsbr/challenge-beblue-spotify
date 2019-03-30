using System;
using SC.Domain.ValueObjects;

namespace SC.Domain.Models
{
    public class Sale
    {
        public Guid Id { get; private set; }
        public DateTime RealizedAt { get; private set; }
        public Amount Price { get; private set; }
        public Amount Cashback { get; private set; }
        public Cpf CustomerCpf { get; private set; }

    }
}