using MedApp.Core.Exceptions;

namespace MedApp.Core.ValueObjects
{
    public record Description
    {
        public string Value { get; }

        public Description(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyDescriptionException();
            }

            Value = value;
        }

        public static implicit operator string(Description description)
            => description.Value;

        public static implicit operator Description(string value)
            => new(value);
    }
}
