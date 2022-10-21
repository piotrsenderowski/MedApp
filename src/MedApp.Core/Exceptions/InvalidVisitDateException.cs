using MedApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.Exceptions
{
    public sealed class InvalidVisitDateException : EntityException
    {
        public DateTime Date { get; }

        public InvalidVisitDateException(DateTime date)
            : base($"Visit date: {date:d} is invalid.")
        {
            Date = date;
        }
    }
}
