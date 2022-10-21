using System;

namespace MedApp.Core.Exceptions
{
    public sealed class ConsultationRoomAlreadyReservedException : EntityException
    {
        public string Name { get; }
        public DateTime Date { get; }

        public ConsultationRoomAlreadyReservedException(string name, DateTime date)
            : base($"Consultation room {name} is already reserved at date: {date:d}.")
        {
            Date = date;
            Name = name;
        }
    }
}
