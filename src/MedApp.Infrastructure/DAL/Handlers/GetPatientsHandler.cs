using MedApp.Application.Abstractions;
using MedApp.Application.DTO;
using MedApp.Application.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Infrastructure.DAL.Handlers
{
    internal sealed class GetPatientsHandler : IQueryHandler<GetPatients, IEnumerable<PatientDto>>
    {
        private readonly MedAppDbContext _dbContext;

        public GetPatientsHandler(MedAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PatientDto>> HandleAsync(GetPatients query)
        {
            var patients = await _dbContext.Patients
                .AsNoTracking()
                .Select(x => x.AsDto())
                .ToListAsync();

            return patients;
        }
    }
}
