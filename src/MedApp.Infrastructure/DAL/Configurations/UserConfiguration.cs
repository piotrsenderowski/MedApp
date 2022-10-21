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
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(x => x.Value, x => new UserId(x));
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Email)
                .HasConversion(x => x.Value, x => new Email(x))
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(x => x.Password)
                .HasConversion(x => x.Value, x => new Password(x))
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasConversion(x => x.Value, x => new FirstName(x))
                .HasMaxLength(150);
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasConversion(x => x.Value, x => new LastName(x))
                .HasMaxLength(150);
            builder.Property(x => x.Role)
                .IsRequired()
                .HasConversion(x => x.Value, x => new Role(x))
                .HasMaxLength(30);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
        }
    }
}