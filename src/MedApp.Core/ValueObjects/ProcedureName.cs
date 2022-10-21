using MedApp.Core.Exceptions;

namespace MedApp.Core.ValueObjects
{
    public record ProcedureName
    {
        public string Value { get; }

        public ProcedureName(string value)        
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyProcedureNameException();
            }

            Value = value;
        }

        public static implicit operator string(ProcedureName name)
            => name.Value;

        public static implicit operator ProcedureName(string value) 
            => new(value);
    }
}
