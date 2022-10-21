using MedApp.Application.Abstractions;
using MedApp.Application.Exceptions;
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
    public sealed class DeleteVisitHandler : ICommandHandler<DeleteVisit>
    {
        private readonly IVisitRepository _visitRepository;

        public DeleteVisitHandler(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        public async Task HandleAsync(DeleteVisit command)
        {
            var visit = await _visitRepository.GetVisitByVisitId(command.VisitId);
            if (visit is null)
            {
                throw new VisitNotFoundException(command.VisitId);
            }
            await _visitRepository.DeleteAsync(visit);
        }

    }
}
