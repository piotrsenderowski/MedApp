using MedApp.Application.Abstractions;
using MedApp.Core.Abstractions;
using MedApp.Core.Entities;
using MedApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Application.Commands.Handlers
{
    internal class AddPatientHandler : ICommandHandler<AddPatient>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IClock _clock;
        public AddPatientHandler(IPatientRepository patientRepository, IClock clock)
        {
            _patientRepository = patientRepository;
            _clock = clock;
        }

        public async Task HandleAsync(AddPatient command)
        {
            var (patientId, firstName, lastName, contactEmail, contactMobile) = command;
            var now = _clock.Current();

            var patient = new Patient(patientId, firstName, lastName, contactEmail, contactMobile, now, now);
            await _patientRepository.AddAsync(patient);
        }
    }
}
