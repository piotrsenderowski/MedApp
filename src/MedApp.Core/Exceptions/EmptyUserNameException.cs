namespace MedApp.Core.Exceptions
{
    public sealed class EmptyUserNameException : EntityException
    {
        public EmptyUserNameException() : base("User name is empty.")
        {
        }
    }
}
