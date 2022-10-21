using MedApp.Core.Exceptions;

namespace MedApp.Core.ValueObjects
{
    public record Email
    {
        public string Value { get; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidEmailException(value);
            }
            
            if (value.Length > 150)
            {
                throw new InvalidEmailException(value);
            }

            Value = value;
        }

        public static implicit operator string(Email name)
            => name.Value;

        public static implicit operator Email(string value)
            => new(value);
    }
}
