namespace MedApp.Core.Exceptions
{
    public sealed class EmptyStatusException : EntityException
    {
        public EmptyStatusException() : base($"Status is empty.")
        {
        }
    }
}
