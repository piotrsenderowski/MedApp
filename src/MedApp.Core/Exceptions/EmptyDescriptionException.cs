namespace MedApp.Core.Exceptions
{
    public sealed class EmptyDescriptionException : EntityException
    {
        public EmptyDescriptionException() : base($"Description is empty.")
        {
        }
    }
}
