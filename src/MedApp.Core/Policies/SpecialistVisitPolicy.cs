using MedApp.Core.Entities;
using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.Policies
{
    internal sealed class SpecialistVisitPolicy : IVisitPolicy
    {
        public bool CanBeApplied(JobTitle jobTitle)
            => jobTitle == JobTitle.Assistant;

        public bool CanReserve(IEnumerable<ConsultationRoom> monthlyConsultationRooms, ProcedureName procedureName)
            => true;
    }
}
