using System;
using System.Collections.Generic;
using System.Text;

namespace MedApp.Core.Exceptions
{
    internal class InvalidRoleException : EntityException
    {
        public InvalidRoleException(string role) : base($"Invalid role: {role}.")
        {

        }
    }
}
