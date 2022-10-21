using MedApp.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Application.Exceptions
{
    public sealed class EmailAlreadyInUseException : EntityException
    {
        public string Email { get; }

        public EmailAlreadyInUseException(string email) : base($"Email: '{email}' is already in use.")
        {
            Email = email;
        }
    }
}
