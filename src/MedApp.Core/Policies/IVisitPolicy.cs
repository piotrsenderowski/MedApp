using MedApp.Core.Entities;
using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.Policies
{
    public interface IVisitPolicy
    {
        bool CanBeApplied(JobTitle jobTitle);
        bool CanReserve(IEnumerable<ConsultationRoom> monthlyConsultationRooms, ProcedureName doctorName);
    }
}
