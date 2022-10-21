using MedApp.Core.Entities;
using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> GetByIdAsync(PatientId id);
        Task AddAsync(Patient patient);
    }
}
