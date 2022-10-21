using MedApp.Core.Abstractions;
using MedApp.Core.Entities;
using MedApp.Core.ValueObjects;
using MedApp.Infrastructure.Time;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedApp.Infrastructure.DAL
{
    internal sealed class DatabaseInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IClock _clock;
        public DatabaseInitializer(IServiceProvider serviceProvider, IClock clock)
        {
            _serviceProvider = serviceProvider;
            _clock = clock;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<MedAppDbContext>();
            await dbContext.Database.MigrateAsync(cancellationToken);

            var consultationRooms = await ReturnConsultationRooms(dbContext);
            await dbContext.ConsultationRooms.AddRangeAsync(consultationRooms);
            await dbContext.SaveChangesAsync(cancellationToken);

            var patients = await ReturnPatients(dbContext);
            await dbContext.Patients.AddRangeAsync(patients);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        private async Task<List<ConsultationRoom>> ReturnConsultationRooms(MedAppDbContext dbContext)
        {

            dbContext.ConsultationRooms.RemoveRange(dbContext.ConsultationRooms);
            
            var consultationRooms = new List<ConsultationRoom>()
            {
                ConsultationRoom.Create(Guid.Parse("00000000-0000-0000-0000-000000000001"), "CR1"),
                ConsultationRoom.Create(Guid.Parse("00000000-0000-0000-0000-000000000002"), "CR2"),
                ConsultationRoom.Create(Guid.Parse("00000000-0000-0000-0000-000000000003"), "CR3"),
            };
            return consultationRooms;
        }

        private async Task<List<Patient>> ReturnPatients(MedAppDbContext dbContext)
        {
            dbContext.Patients.RemoveRange(dbContext.Patients);
            var patients = new List<Patient>()
            {
                Patient.Create(Guid.Parse("00000000-0000-0000-0001-000000000001"), "Patient1F", "Patient1L", "patient1@email.com", "111111111111", _clock.Current().AddDays(-3), _clock.Current().AddDays(-1)),
                Patient.Create(Guid.Parse("00000000-0000-0000-0002-000000000002"), "Patient2F", "Patient2L", "patient2@email.com", "222222222222", _clock.Current().AddDays(-2), _clock.Current().AddDays(-2)),
                Patient.Create(Guid.Parse("00000000-0000-0000-0003-000000000003"), "Patient3F", "Patient3L", "patient3@email.com", "333333333333", _clock.Current().AddDays(-1), _clock.Current().AddDays(-3)),
            };
            return patients;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
