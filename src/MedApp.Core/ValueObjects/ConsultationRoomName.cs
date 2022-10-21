using MedApp.Core.Exceptions;

namespace MedApp.Core.ValueObjects
{
    public record ConsultationRoomName
    {
        public string Value { get; }

        public ConsultationRoomName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyConsultationRoomNameException();
            }

            Value = value;
        }

        public static implicit operator string(ConsultationRoomName name)
            => name.Value;

        public static implicit operator ConsultationRoomName(string value)
            => new(value);
    }
}
