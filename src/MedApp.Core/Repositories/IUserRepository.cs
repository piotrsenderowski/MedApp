using MedApp.Core.Entities;
using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(UserId id);
        Task<User> GetByEmailAsync(Email email);
        Task<User> GetByUserNameAsync(string userName);
        Task AddAsync(User user);
    }
}
