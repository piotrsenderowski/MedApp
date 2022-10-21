using MedApp.Core.Criterias;
using MedApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Infrastructure.DAL.Criterias
{
    internal class VisitsCritieraDoctorName : IVisitsCriteria
    {
        public IEnumerable<Visit> MeetCriteria(IEnumerable<Visit> visits, object criterium)
        {
            var doctorsVisits = visits.Where(x => x.Doctor.UserName.ToLowerInvariant == criterium.ToString().ToLowerInvariant).ToList();
            return doctorsVisits;
        }
    }
}
