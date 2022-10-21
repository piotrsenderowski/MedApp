using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.ValueObjects
{
    public sealed record Month
    {
        public Date From { get; }
        public Date To { get; }

        public Month(DateTime value)
        {
            From = new DateTime(value.Year, value.Month, 1);
            DateTime dateTime = From;
            To = dateTime.AddMonths(1).AddDays(-1);
        }

        public override string ToString() => $"{From} -> {To}";

    }
}
