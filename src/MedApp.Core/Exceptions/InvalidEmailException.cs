using System;
using System.Collections.Generic;
using System.Text;

namespace MedApp.Core.Exceptions
{
    internal class InvalidEmailException : EntityException
    {
        public InvalidEmailException(string email) : base($"Invalid email: {email}.")
        {

        }
    }
}
