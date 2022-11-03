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
    internal sealed class SqlServerVisitRepository : IVisitRepository
    {
        private readonly DbSet<Visit> _visits;
        private readonly MedAppDbContext _dbContext;

        public SqlServerVisitRepository(MedAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _visits = dbContext.Visits;
        }

        public async Task<Visit> GetVisitByVisitId(VisitId id)
            => await _visits
                .SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Visit>> GetVisitsByPatientId(PatientId id)
        {
            var result = await _visits
                .Include(x => x.Patient).Where(x => x.PatientId == id)
                .ToListAsync();
            return result.AsEnumerable();
        }

        public async Task AddAsync(Visit visit)
        {
            var allConsultationRoomVisits = await _visits.Where(x => x.ConsultationRoomId == visit.ConsultationRoomId).ToListAsync();
            var allTodaysConsultationRoomVisit = allConsultationRoomVisits.Where(x => x.DateFrom_planned.Value.Date == visit.DateFrom_planned.Value.Date && x.DateTo_planned.Value.Date == visit.DateTo_planned.Value.Date).ToList();
            if (allTodaysConsultationRoomVisit.Any())
            {
                var isVisitDateIsValid = IsVisitDateValid(visit, allTodaysConsultationRoomVisit);
                if (!isVisitDateIsValid)
                {
                    throw new Exception();
                }
            }

            await _visits.AddAsync(visit);

        }

        public async Task UpdateAsync(Visit visit)
            => _visits.Update(visit);

        public async Task DeleteAsync(Visit visit)
            => _visits.Remove(visit);


        bool IsVisitDateValid(Visit newVisit, IEnumerable<Visit> existingVisits)
        { 
            foreach (Visit visit in existingVisits)
            {
                var isDateFromBetween = IsDateTimeBetween(newVisit.DateFrom_planned, visit.DateFrom_planned, visit.DateTo_planned);
                var isDateToBetween = IsDateTimeBetween(newVisit.DateTo_planned, visit.DateFrom_planned, visit.DateTo_planned);
                if (isDateFromBetween || isDateToBetween)
                {
                    return false;
                }
            }
            return true;
        }

        bool IsDateTimeBetween(DateTime dateToCheck, DateTime start, DateTime end)
        {
            if (start < end)
            {
                return start <= dateToCheck && dateToCheck <= end;
            }
            return !(end < dateToCheck && dateToCheck < start);
        }
    }
}
