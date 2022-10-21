using MedApp.Core.ValueObjects;

namespace MedApp.Application.DTO
{
    public class VisitDto
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Guid ConsultationRoomId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string ProcedureName { get; set; }
        public string Description { get; set; }
    }
}
