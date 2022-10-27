using MedApp.Core.Entities;
using MedApp.Core.Repositories;
using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Tests.Integration
{
    internal class TestUserRepository : IUserRepository
    {
        private readonly List<User> _users = new();
        public Task AddAsync(User user)
        {
            _users.Add(user);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByEmailAsync(Email email)
            => Task.FromResult(_users.SingleOrDefault(x => x.Email == email));

        public Task<User> GetByIdAsync(UserId id)
            => Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

        public Task<User> GetByUserNameAsync(string userName)
            => Task.FromResult(_users.SingleOrDefault(x => x.UserName == userName));
    }
}
