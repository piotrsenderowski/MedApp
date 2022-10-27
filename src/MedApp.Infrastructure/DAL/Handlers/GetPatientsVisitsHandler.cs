using MedApp.Application.Abstractions;
using MedApp.Application.DTO;
using MedApp.Application.Queries;
using MedApp.Core.Entities;
using MedApp.Core.Repositories;
using MedApp.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedApp.Infrastructure.DAL.Handlers
{
    internal sealed class GetPatientsVisitsHandler : IQueryHandler<GetPatientsVisits, IEnumerable<VisitDto>>
    {
        private readonly MedAppDbContext _dbContext;
        private readonly IVisitRepository _repository;


        public GetPatientsVisitsHandler(MedAppDbContext dbContext, IVisitRepository repository)
        {
            _dbContext = dbContext;
            _repository = repository;
        }



        public async Task<IEnumerable<VisitDto>> HandleAsync(GetPatientsVisits query)
        {
            var patientId = new PatientId(query.PatientId);
            var visits = await _repository.GetVisitsByPatientId(patientId);

            return visits.Select(x => x.AsDto());
        }
    }
}
