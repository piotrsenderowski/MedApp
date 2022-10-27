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

            var consultationRooms = new List<ConsultationRoom>();
            for (int i = 1; i <= 5; i++)
            {   
                var id = Guid.Parse($"00000000-0000-0000-0000-00000000000{i}");
                var consultationRoom = ConsultationRoom.Create(id, $"CR{i}");
                consultationRooms.Add(consultationRoom);
            }

            return consultationRooms;
        }

        private async Task<List<Patient>> ReturnPatients(MedAppDbContext dbContext)
        {
            dbContext.Patients.RemoveRange(dbContext.Patients);
            var patients = new List<Patient>();
            for (int i = 1; i <= 5; i++)
            {
                var id = Guid.Parse($"00000000-0000-0000-0000-00000000000{i}");
                var patient = Patient.Create(id, Faker.Name.First(), Faker.Name.Last(), Faker.Internet.Email(), Faker.Phone.Number(), _clock.Current().AddDays(-3), _clock.Current().AddDays(-1));
                patients.Add(patient);
            };
            return patients;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
