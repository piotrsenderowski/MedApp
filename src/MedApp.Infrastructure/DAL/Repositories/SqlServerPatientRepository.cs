using MedApp.Core.Entities;
using MedApp.Core.Repositories;
using MedApp.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Infrastructure.DAL.Repositories
{
    internal sealed class SqlServerPatientRepository : IPatientRepository
    {
        private readonly DbSet<Patient> _patients;
        public SqlServerPatientRepository(MedAppDbContext dbContext)
        {
            _patients = dbContext.Patients;
        }
        public async Task AddAsync(Patient patient)
            => await _patients.AddAsync(patient);

        public async Task<Patient> GetByIdAsync(PatientId id)
            => await _patients.SingleOrDefaultAsync(x => x.Id == id);
    }
}
