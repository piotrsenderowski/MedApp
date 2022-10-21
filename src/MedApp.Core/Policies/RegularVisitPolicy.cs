using MedApp.Core.Abstractions;
using MedApp.Core.Entities;
using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.Policies
{
    internal sealed class RegularVisitPolicy : IVisitPolicy
    {
        public bool CanBeApplied(JobTitle jobTitle)
            => jobTitle == JobTitle.Doctor;

        public bool CanReserve(IEnumerable<ConsultationRoom> monthlyConsultationRooms, ProcedureName doctorName)
            => true;
    }
}
