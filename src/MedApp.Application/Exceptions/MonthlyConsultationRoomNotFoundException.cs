using MedApp.Core.Exceptions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Application.Exceptions
{
    public class MonthlyConsultationRoomNotFoundException : EntityException
    {
        public Guid Id { get; }
        public MonthlyConsultationRoomNotFoundException()
            : base($"Monthly consultation room was not found")
        {
        }

        public MonthlyConsultationRoomNotFoundException(Guid id)
            : base($"Monthly consultation room with ID: {id} was not found")
        {
            Id = id;
        }
    }
}
