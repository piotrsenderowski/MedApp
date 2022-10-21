using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.Exceptions
{
    public sealed class CannotReserveConsultationRoomException : EntityException
    {
        public ConsultationRoomId ConsultationRoomId { get; }

        public CannotReserveConsultationRoomException(ConsultationRoomId consultationRoomId)
            : base($"Cannot reserve consultation room with ID: {consultationRoomId}")
        {
            ConsultationRoomId = consultationRoomId;
        }
    }
}
