using MedApp.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.ValueObjects
{
    public record Mobile
    {
        public string Value { get; }

        public Mobile(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidMobileException(value);
            }

            if (value.Length > 150)
            {
                throw new InvalidMobileException(value);
            }

            Value = value;
        }

        public static implicit operator string(Mobile name)
            => name.Value;

        public static implicit operator Mobile(string value)
            => new(value);
    }
}
