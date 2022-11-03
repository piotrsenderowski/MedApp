namespace MedApp.Core.Exceptions
{
    internal class InvalidStatusException : EntityException
    {
        public InvalidStatusException(string status) : base($"Invalid status: {status}.")
        {

        }
    }
}
