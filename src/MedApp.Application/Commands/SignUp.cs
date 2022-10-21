using MedApp.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Application.Commands
{
    public record SignUp(Guid UserId, string Email, string Password,
        string FirstName, string LastName, string Role) : ICommand;
    
}
