using MedApp.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Application.Commands
{
    public record SignIn(string Email, string Password) : ICommand;
}
