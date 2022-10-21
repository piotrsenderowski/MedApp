using MedApp.Core.Exceptions;

namespace MedApp.Core.ValueObjects
{
    public record Password
    {
        public string Value { get; }

        public Password(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidPasswordException();
            }

            if (value.Length < 6 && value.Length > 200)
            {
                throw new InvalidPasswordException();
            }

            Value = value;
        }

        public static implicit operator string(Password value)
            => value.Value;

        public static implicit operator Password(string value)
            => new(value);
    }
}
