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
    internal sealed class GetUserHandler : IQueryHandler<GetUser, UserDto>
    {
        private readonly MedAppDbContext _dbContext;

        public GetUserHandler(MedAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDto> HandleAsync(GetUser query)
        {
            var userId = new UserId(query.UserId);
            var user = await _dbContext.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == userId);

            return user?.AsDto();
        }
    }
}
