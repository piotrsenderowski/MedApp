using MedApp.Core.Exceptions;

namespace MedApp.Application.Exceptions
{
    public class PatientNotFoundException : EntityException
    {
        public Guid Id { get; }

        public PatientNotFoundException(Guid id)
            : base($"Patient with ID: {id} was not found")
        {
            Id = id;
        }
    }
}
