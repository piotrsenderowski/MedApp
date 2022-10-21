namespace MedApp.Core.Exceptions
{
    public sealed class EmptyFirstNameException : EntityException
    {
        public EmptyFirstNameException() : base("First name is empty.")
        {
        }
    }
}
