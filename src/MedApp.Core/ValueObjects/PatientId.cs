using MedApp.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.ValueObjects
{
    public sealed record PatientId
    {
        public Guid Value { get; }

        public PatientId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidEntityIdException(value);
            }

            Value = value;
        }

        public static implicit operator Guid(PatientId id)
            => id.Value;

        public static implicit operator PatientId(Guid value)
            => new(value);
    }
}
