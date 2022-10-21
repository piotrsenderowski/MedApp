using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.ValueObjects
{
    public sealed record JobTitle
    {
        public string Value { get; }

        public const string Owner = nameof(Owner);
        public const string Doctor = nameof(Doctor);
        public const string Assistant = nameof(Assistant);
        

        private JobTitle(string value)
            => Value = value;

        public static implicit operator string(JobTitle jobTitle)
            => jobTitle.Value;

        public static implicit operator JobTitle(string value)
            => new(value);
    }
}
