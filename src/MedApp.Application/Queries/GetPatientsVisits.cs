using MedApp.Application.Abstractions;
using MedApp.Application.DTO;

namespace MedApp.Application.Queries
{
    public class GetPatientsVisits : IQuery<IEnumerable<VisitDto>>
    {
        public DateTime? Date { get; set; }
        public Guid PatientId { get; set; }
    }
}
