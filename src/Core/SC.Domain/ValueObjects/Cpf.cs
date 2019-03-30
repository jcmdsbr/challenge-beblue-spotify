using System;

namespace SC.Domain.ValueObjects
{
    public class Cpf : ValueObject<Cpf>
    {
        protected Cpf()
        {
        }

        public Cpf(string value)
        {
            var valueFormt = (value ?? string.Empty).Replace(".", "").Replace("/", "").Replace("-", "");
            Value = Convert.ToDecimal(valueFormt);
        }

        public decimal Value { get; }

        public override string ToString()
        {
            return string.Format(@"000\.000\.000\-00", Value);
        }

        public static Cpf Create(string value)
        {
            return new Cpf(value);
        }

        public static implicit operator string(Cpf cpf)
        {
            return cpf?.Value.ToString();
        }

        public static implicit operator Cpf(string value)
        {
            return new Cpf(value);
        }

        protected override bool EqualsCore(Cpf other)
        {
            return other.Value == Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }
    }
}