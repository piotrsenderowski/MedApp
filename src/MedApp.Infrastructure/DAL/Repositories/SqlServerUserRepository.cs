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
    internal sealed class SqlServerUserRepository : IUserRepository
    {
        private readonly DbSet<User> _users;

        public SqlServerUserRepository(MedAppDbContext dbContext)
        {
            _users = dbContext.Users;
        }
        public Task<User> GetByIdAsync(UserId id)
            => _users.SingleOrDefaultAsync(x => x.Id == id);

        public Task<User> GetByEmailAsync(Email email)
            => _users.SingleOrDefaultAsync(x => x.Email == email);

        public Task<User> GetByUserNameAsync(string userName)
            => _users.SingleOrDefaultAsync(x => x.UserName == userName);

        public async Task AddAsync(User user)
        {
            await _users.AddAsync(user);
        }

        public async Task DeleteAsync(User user)
        {
            _users.Remove(user);
        }
    }
}
