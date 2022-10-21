using MedApp.Core.Entities;
using MedApp.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedApp.Infrastructure.DAL.Configurations
{
    internal sealed class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(x => x.Value, x => new PatientId(x));
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasConversion(x => x.Value, x => new FirstName(x))
                .HasMaxLength(150);
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasConversion(x => x.Value, x => new LastName(x))
                .HasMaxLength(150);
            builder.Property(x => x.ContactEmail)
                .HasConversion(x => x.Value, x => new Email(x))
                .HasMaxLength(150);
            builder.Property(x => x.ContactMobile)
                .HasConversion(x => x.Value, x => new Mobile(x))
                .HasMaxLength(150);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
        }
    }
}