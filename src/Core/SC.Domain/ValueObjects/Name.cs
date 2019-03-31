namespace SC.Domain.ValueObjects
{
    public class Name : ValueObject<Name>
    {
        protected Name()
        {
        }

        public Name(string value) => Value = value;

        public string Value { get; private set; }

        public override string ToString()
        {
            return Value;
        }

        public static implicit operator string(Name name)
        {
            return name?.Value;
        }

        public static implicit operator Name(string value)
        {
            return new Name(value);
        }

        protected override bool EqualsCore(Name other)
        {
            return other.Value.ToUpper().Equals(Value.ToUpper());
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode() ^ 1254;
        }
    }
}