using MedApp.Core.Entities;
using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.Repositories
{
    public interface IVisitRepository
    {
        Task<Visit> GetVisitByVisitId(VisitId id);
        Task <IEnumerable<Visit>> GetVisitsByPatientId(PatientId id);
        Task AddAsync(Visit visit);
        Task UpdateAsync(Visit visit);
        Task DeleteAsync(Visit visit);
    }
}
