using MedApp.Application.Abstractions;
using MedApp.Application.Exceptions;
using MedApp.Core.Abstractions;
using MedApp.Core.Entities;
using MedApp.Core.Repositories;
using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Application.Commands.Handlers
{

    public sealed class CreateVisitHandler : ICommandHandler<CreateVisit>
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPatientRepository _patientRepository;

        public CreateVisitHandler(IVisitRepository visitRepository,
            IUserRepository userRepository,
            IPatientRepository patientRepository)
        {
            _visitRepository = visitRepository;
            _userRepository = userRepository;
            _patientRepository = patientRepository;
        }

        public async Task HandleAsync(CreateVisit command)
        {
            var (visitId, doctorId, patientId, consultationRoomId, dateFrom, dateTo, procedureName, description) = command;

            var doctor = await _userRepository.GetByIdAsync(doctorId);
            if (doctor == null)
            {
                throw new UserNotFoundException(doctorId);
            }

            var patient = await _patientRepository.GetByIdAsync(patientId);
            if (patient == null)
            {
                throw new PatientNotFoundException(patientId);
            }

            var visit = new Visit(visitId, doctorId, patientId, consultationRoomId, dateFrom, dateTo, procedureName, description);
            await _visitRepository.AddAsync(visit);
        }
    }
}
