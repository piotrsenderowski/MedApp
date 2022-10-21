using System;
using System.Collections.Generic;
using System.Text;

namespace MedApp.Core.Exceptions
{
    public abstract class EntityException : Exception
    {
        protected EntityException(string message) : base(message)
        {

        }

    }
}
