using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Infrastructure.DAL
{
    internal interface IUnitOfWork
    {
        Task ExecuteAsync(Func<Task> action);
    }
}
