using MedApp.Core.Entities;
using MedApp.Core.Exceptions;
using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Infrastructure.Strategies
{
    internal class VisitStrategyConfirm : IVisitStrategy
    {
        public Visit ModifyStatus(Visit visit)
        {
            if (visit.Status != Status.Reserved)
            {
                throw new CannotModifyStatusException(Status.Confirmed);
            }
            visit.Status = Status.Confirmed;
            return visit;
        }
    }
}
