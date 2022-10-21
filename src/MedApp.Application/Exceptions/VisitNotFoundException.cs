using MedApp.Core.Exceptions;

namespace MedApp.Application.Exceptions
{
    public class VisitNotFoundException : EntityException
    {
        public Guid Id { get; }

        public VisitNotFoundException(Guid id)
            : base($"Visit with ID: {id} was not found")
        {
            Id = id;
        }
    }
}
