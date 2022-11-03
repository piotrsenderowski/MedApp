using MedApp.Core.ValueObjects;

namespace MedApp.Core.Exceptions
{
    public sealed class CannotModifyStatusException : EntityException
    {
        public Status Status { get; }

        public CannotModifyStatusException(Status status)
            : base($"Cannot set status to: {status}")
        {
            Status = status;
        }
    }
}
