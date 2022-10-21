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
    internal sealed class GetUsersHandler : IQueryHandler<GetUsers, IEnumerable<UserDto>>
    {
        private readonly MedAppDbContext _dbContext;

        public GetUsersHandler(MedAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<UserDto>> HandleAsync(GetUsers query)
        {
            var users = await _dbContext.Users
                .AsNoTracking()
                .Select(x => x.AsDto())
                .ToListAsync();

            return users;
        }
    }
}
