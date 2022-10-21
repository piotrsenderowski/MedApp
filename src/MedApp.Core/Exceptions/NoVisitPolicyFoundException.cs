using MedApp.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.Exceptions
{
    public sealed class NoVisitPolicyFoundException : EntityException
    {
        public JobTitle JobTitle { get; }
        public NoVisitPolicyFoundException(JobTitle jobTitle)
            : base($"No visit policy for {jobTitle} has been found.")
        {
            JobTitle = jobTitle;
        }
    }
}
