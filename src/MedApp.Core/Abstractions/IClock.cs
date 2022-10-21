using System;

namespace MedApp.Core.Abstractions
{
    public interface IClock
    {
        DateTime Current();
    }
}
