using MedApp.Core.Exceptions;

namespace MedApp.Core.ValueObjects
{
    public record LastName
    {
        public string Value { get; }

        public LastName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyLastNameException();
            }

            Value = value;
        }

        public static implicit operator string(LastName name)
            => name.Value;

        public static implicit operator LastName(string name)
            => new(name);
    }
}
