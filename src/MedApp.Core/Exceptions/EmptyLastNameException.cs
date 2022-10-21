namespace MedApp.Core.Exceptions
{
    public sealed class EmptyLastNameException : EntityException
    {
        public EmptyLastNameException() : base("Last name is empty.")
        {
        }
    }


}
