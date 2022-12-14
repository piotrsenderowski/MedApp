using MedApp.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Application.Exceptions
{
    public class UserNotFoundException : EntityException
    {
        public Guid Id { get; }
        public string Email{ get; }

        public UserNotFoundException(Guid id)
            : base($"User with ID: {id} was not found")
        {
            Id = id;
        }
        public UserNotFoundException(string email)
            : base($"User with ID: {email} was not found")
        {
            Email = email;
        }
    }
}
