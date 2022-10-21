using MedApp.Core.Exceptions;
using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MedApp.Core.Entities
{
    public class User
    {
        public UserId Id { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public Role Role { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public readonly string UserName;

        public User(UserId id, Email email, Password password, FirstName firstName, LastName lastName,
            Role role, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            UserName = string.Concat(firstName, lastName);
            Role = role;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

    }
}
