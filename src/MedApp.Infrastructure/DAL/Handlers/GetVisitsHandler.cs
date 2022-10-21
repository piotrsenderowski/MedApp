using MedApp.Application.Abstractions;
using MedApp.Application.DTO;
using MedApp.Application.Queries;
using MedApp.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Infrastructure.DAL.Handlers
{
    internal sealed class GetVisitsHandler : IQueryHandler<GetVisits, IEnumerable<VisitDto>>
    {
        private readonly MedAppDbContext _dbContext;

        public GetVisitsHandler(MedAppDbContext dbContext)
            => _dbContext = dbContext;


        public async Task<IEnumerable<VisitDto>> HandleAsync(GetVisits query)
        {
            var visits = await _dbContext.Visits
                .AsNoTracking()
                .ToListAsync();

            return visits.Select(x => x.AsDto());
        }
    }
}
