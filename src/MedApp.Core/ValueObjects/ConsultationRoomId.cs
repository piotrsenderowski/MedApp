using MedApp.Core.Exceptions;
using System;

namespace MedApp.Core.ValueObjects
{
    public sealed record ConsultationRoomId
    {
        public Guid Value { get; }

        public ConsultationRoomId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidEntityIdException(value);
            }

            Value = value;
        }

        public static ConsultationRoomId Create() => new(Guid.NewGuid());

        public static implicit operator Guid(ConsultationRoomId id)
            => id.Value;

        public static implicit operator ConsultationRoomId(Guid value)
            => new(value);

        public override string ToString() => Value.ToString("N");
    }
}
