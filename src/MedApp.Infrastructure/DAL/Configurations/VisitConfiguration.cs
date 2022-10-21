using MedApp.Core.Entities;
using MedApp.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Infrastructure.DAL.Configurations
{
    internal sealed class VisitConfiguration : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            //builder.HasOne<User>().WithMany().HasForeignKey(x => x.DoctorId);
            //builder.HasOne<Patient>().WithMany().HasForeignKey(x => x.PatientId);
            //builder.HasOne<ConsultationRoom>().WithMany().HasForeignKey(x => x.ConsultationRoomId);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(x => x.Value, x => new VisitId(x));
            builder.Property(x => x.DoctorId)
                .HasConversion(x => x.Value, x => new UserId(x));
            builder.Property(x => x.PatientId)
                .HasConversion(x => x.Value, x => new PatientId(x));
            builder.Property(x => x.ConsultationRoomId)
                .HasConversion(x => x.Value, x => new ConsultationRoomId(x));
            builder.Property(x => x.DateFrom)
                .IsRequired()
                .HasConversion(x => x.Value, x => new Date(x));
            builder.Property(x => x.DateTo)
                .IsRequired()
                .HasConversion(x => x.Value, x => new Date(x));
            builder.Property(x => x.ProcedureName)
                .HasConversion(x => x.Value, x => new ProcedureName(x));
            builder.Property(x => x.Description)
                .HasConversion(x => x.Value, x => new Description(x));
        }
    }
}
