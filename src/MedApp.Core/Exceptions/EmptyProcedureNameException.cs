namespace MedApp.Core.Exceptions
{
    public sealed class EmptyProcedureNameException : EntityException
    {
        public EmptyProcedureNameException() : base($"Procedure name is empty.")
        {
        }
    }
}
