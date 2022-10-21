using MedApp.Core.Exceptions;
using System;

namespace MedApp.Core.ValueObjects
{
    public sealed record VisitId
    {
        public Guid Value { get; }

        public VisitId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidEntityIdException(value);
            }

            Value = value;
        }

        public static VisitId Create() => new(Guid.NewGuid());

        public static implicit operator Guid(VisitId id)
            => id.Value;

        public static implicit operator VisitId(Guid value)
            => new(value);

        public override string ToString() => Value.ToString("N");
    }
}
