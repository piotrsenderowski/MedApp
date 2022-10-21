using MedApp.Core.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace MedApp.Core.ValueObjects
{
    public record Role
    {
        private static IEnumerable<string> AvailableRoles { get; } = new[] {"admin", "doctor", "assistant"};
        public string Value { get; }

        public Role(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidRoleException(value);
            }

            value = value.ToLowerInvariant();
            if (!AvailableRoles.Contains(value))
            {
                throw new InvalidRoleException(value);
            }
            Value = value;
        }

        public static Role Admin() => new("admin");
        public static Role Doctor() => new("doctor");
        public static Role Assistant() => new("assistant");

        public static implicit operator string(Role role)
            => role.Value;

        public static implicit operator Role(string role)
            => new(role);
        public override string ToString() => Value;
    }
}
