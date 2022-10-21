using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.ValueObjects
{
    public sealed record Date
    {
        public DateTime Value { get; }
        
        public Date(DateTime value)
        {
            Value = value;
        }

        public Date AddDays(int days) => new(Value.AddDays(days));

        public static implicit operator DateTime(Date date) 
            => date.Value;

        public static implicit operator Date(DateTime value)
            => new(value);

        public static bool operator <(Date date1, Date date2)
            => date1.Value < date2.Value;

        public static bool operator >(Date date1, Date date2)
            => date1.Value > date2.Value;

        public static bool operator <=(Date date1, Date date2)
            => date1.Value < date2.Value;

        public static bool operator >=(Date date1, Date date2)
            => date1.Value > date2.Value;

        public static Date Now => new(DateTime.Now);
    }
}
