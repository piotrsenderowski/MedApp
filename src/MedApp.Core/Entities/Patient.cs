using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;

namespace MedApp.Core.Entities
{
    public class Patient
    {
        public PatientId Id { get; private set; }
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public Email ContactEmail { get; private set; }
        public Mobile ContactMobile { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public readonly string UserName;

        protected Patient()
        {
        }

        public Patient(PatientId id, FirstName firstName, LastName lastName, Email email,
            Mobile mobile, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            ContactEmail = email;
            ContactMobile = mobile;
            UserName = string.Concat(firstName, lastName);
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static Patient Create(PatientId id, FirstName firstName, LastName lastName, Email email,
            Mobile mobile, DateTime createdAt, DateTime updatedAt)
            => new(id, firstName, lastName, email, mobile, createdAt, updatedAt);

    }
}
