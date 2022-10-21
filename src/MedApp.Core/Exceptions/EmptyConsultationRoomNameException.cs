namespace MedApp.Core.Exceptions
{
    public sealed class EmptyConsultationRoomNameException : EntityException
    {
        public EmptyConsultationRoomNameException() : base($"Consultation room name is empty.")
        {
        }
    }
}
