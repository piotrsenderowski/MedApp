using MedApp.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Tests.Unit.Shared
{
    public class TestClock : IClock
    {
        public DateTime Current() => new DateTime(2022, 09, 29, 12, 0, 0);
    }
}
