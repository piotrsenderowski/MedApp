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
    internal sealed class GetVisitHandler : IQueryHandler<GetVisit, VisitDto>
    {
        private readonly MedAppDbContext _dbContext;

        public GetVisitHandler(MedAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<VisitDto> HandleAsync(GetVisit query)
        {
            var visitId = new VisitId(query.VisitId);
            var dbContext = _dbContext;
            var visit = await dbContext.Visits
                //.AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == visitId);

            return visit?.AsDto();
        }
    }
}
