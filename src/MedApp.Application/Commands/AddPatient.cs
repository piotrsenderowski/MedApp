using MedApp.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Application.Commands
{
    public record AddPatient(Guid PatientId, string FirstName, string LastName,
        string ContactEmail, string ContactMobile) : ICommand;
}
