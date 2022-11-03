using MedApp.Application.DTO;
using MedApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Infrastructure.DAL.Handlers
{
    internal static class Extensions
    {
        public static VisitDto AsDto(this Visit entity)
            => new()
            {
                Id = entity.Id,
                DoctorId = entity.DoctorId,
                PatientId = entity.PatientId,
                ConsultationRoomId = entity.ConsultationRoomId,
                DateFrom = entity.DateFrom_planned,
                DateTo = entity.DateTo_planned,
                ProcedureName = entity.ProcedureName,
                Description = entity.Description
            };
        
        public static UserDto AsDto(this User entity)
            => new()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };

        public static PatientDto AsDto(this Patient entity)
            => new()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                ContactEmail = entity.ContactEmail,
                ContactMobile = entity.ContactMobile
            };
    }
}
