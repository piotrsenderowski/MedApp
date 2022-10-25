using MedApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.Criterias
{
    public interface IVisitsCriteria
    {
        Task<IEnumerable<Visit>> MeetCriteria(IEnumerable<Visit> visits, object criterium);
    }
}
