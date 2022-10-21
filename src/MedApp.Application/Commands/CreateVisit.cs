using MedApp.Application.Abstractions;
using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Application.Commands
{
    public record CreateVisit(Guid VisitId, Guid DoctorId, Guid PatientId, Guid ConsultationRoomId, 
        DateTime DateFrom, DateTime DateTo, string ProcedureName, string Description) : ICommand;

}
