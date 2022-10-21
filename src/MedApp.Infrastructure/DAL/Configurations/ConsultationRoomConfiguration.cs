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
    internal sealed class ConsultationRoomConfiguration : IEntityTypeConfiguration<ConsultationRoom>
    {
        public void Configure(EntityTypeBuilder<ConsultationRoom> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(x => x.Value, x => new ConsultationRoomId(x));
            builder.Property(x => x.Name)
                .IsRequired()
                .HasConversion(x => x.Value, x => new ConsultationRoomName(x));
        }
    }
}
