namespace MedApp.Core.Exceptions
{
    public sealed class InvalidCapacityException : EntityException
    {
        public int Capacity;

        public InvalidCapacityException(int capacity)
            : base($"Capacity: {capacity} is invalid.")
        {
            Capacity = capacity;
        }
    }
}
