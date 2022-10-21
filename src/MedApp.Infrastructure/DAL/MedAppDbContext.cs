using MedApp.Core.Entities;
using MedApp.Infrastructure.DAL.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Infrastructure.DAL
{
    public sealed class MedAppDbContext : DbContext 
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<ConsultationRoom> ConsultationRooms { get; set; }

        public MedAppDbContext(DbContextOptions<MedAppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
