using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.Exceptions
{
    public sealed class ConsultationRoomCapacityExceededException : EntityException
    {
        public ConsultationRoomId ConsultationRoomId { get; }
        public ConsultationRoomCapacityExceededException(ConsultationRoomId consultationRoomId)
            : base($"Consultation room with ID: {consultationRoomId} exceeds its visit capacity.")
        {
            ConsultationRoomId = consultationRoomId;
        }
    }
}
