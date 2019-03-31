using System.Globalization;
using SC.Core.ValueObjects;

namespace SC.Domain.ValueObjects
{
    public class Amount : ValueObject<Amount>
    {
        protected Amount()
        {
        }

        public Amount(decimal value) => Value = value;

        private Amount(string value) => Value = decimal.Parse(value, NumberStyles.Currency, CultureInfo.InvariantCulture);

        public decimal Value { get; private set; }

        public override string ToString()
        {
            return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", Value);
        }

        public static implicit operator string(Amount amount)
        {
            return amount?.Value.ToString();
        }

        public static implicit operator decimal(Amount amount)
        {
            return amount?.Value ?? default;
        }

        public static implicit operator Amount(decimal value)
        {
            return new Amount(value);
        }

        public static implicit operator Amount(string value)
        {
            return new Amount(value);
        }

        protected override bool EqualsCore(Amount other)
        {
            return other.Value == Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}