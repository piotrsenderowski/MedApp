using MedApp.Core.Exceptions;

namespace MedApp.Core.ValueObjects
{
    public record FirstName
    {
        public string Value { get; }

        public FirstName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyFirstNameException();
            }

            Value = value;
        }

        public static implicit operator string(FirstName name)
            => name.Value;

        public static implicit operator FirstName(string name)
            => new(name);
    }
}
