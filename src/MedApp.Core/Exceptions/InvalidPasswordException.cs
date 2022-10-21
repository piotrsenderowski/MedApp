using System;
using System.Collections.Generic;
using System.Text;

namespace MedApp.Core.Exceptions
{
    internal class InvalidPasswordException : EntityException
    {
        public InvalidPasswordException() : base($"Password is invalid.")
        {
        }
    }
    
}
