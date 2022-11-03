using MedApp.Core.Exceptions;
using System.Linq;
using System.Reflection;

namespace MedApp.Core.ValueObjects
{
    public record Status
    {
        public string Value { get; }

        public const string Reserved = nameof(Reserved);
        public const string Confirmed = nameof(Confirmed);
        public const string Ongoing = nameof(Ongoing);
        public const string Completed = nameof(Completed);
        public const string Cancelled = nameof(Cancelled);

        public Status(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyStatusException();
            }

            var possibleStatuses = typeof(Status).GetFields().Select(x => x.GetRawConstantValue()).ToList();
            if (!possibleStatuses.Contains(value))
            {
                throw new InvalidStatusException(value);
            }

            Value = value;
        }

        public static implicit operator string(Status value)
            => value.Value;

        public static implicit operator Status(string value)
            => new(value);
    }
}
