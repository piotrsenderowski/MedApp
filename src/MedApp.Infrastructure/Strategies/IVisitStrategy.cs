using MedApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Infrastructure.Strategies
{
    internal interface IVisitStrategy
    {
        Visit ModifyStatus(Visit visit);
    }
}
