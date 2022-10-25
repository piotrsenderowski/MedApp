using MedApp.Core.Exceptions;
using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.Entities
{
    public class Visit
    {
        public VisitId Id { get; private set; }
        public UserId DoctorId { get; private set; }
        public PatientId PatientId { get; private set; }
        public ConsultationRoomId ConsultationRoomId { get; private set; }
        public Date DateFrom { get; private set; }
        public Date DateTo { get; private set; }
        public ProcedureName ProcedureName { get; private set; }
        public Description Description { get; private set; }

        public Visit(VisitId id, UserId doctorId, 
            PatientId patientId, ConsultationRoomId consultationRoomId,
            Date dateFrom, Date dateTo, ProcedureName procedureName,
            Description description)
        {
            Id = id;
            DoctorId = doctorId;
            PatientId = patientId;
            ConsultationRoomId = consultationRoomId;
            DateFrom = dateFrom;
            DateTo = dateTo;
            ProcedureName = procedureName;
            Description = description;
        }
    }
}
