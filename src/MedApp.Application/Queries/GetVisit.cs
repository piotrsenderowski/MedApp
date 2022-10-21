using MedApp.Application.Abstractions;
using MedApp.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Application.Queries
{
    public class GetVisit : IQuery<VisitDto>
    {
        public DateTime? Date { get; set; }
        public Guid VisitId { get; set; }
    }
}
