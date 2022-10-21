using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.Exceptions
{
    internal class InvalidMobileException : EntityException
    {
        public InvalidMobileException(string mobile) : base($"Invalid mobile: {mobile}.")
        {

        }
    }
}
