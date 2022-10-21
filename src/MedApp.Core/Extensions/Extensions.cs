using MedApp.Core.Policies;
using MedApp.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Core.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddSingleton<IVisitPolicy, RegularVisitPolicy>();
            services.AddSingleton<IVisitPolicy, SpecialistVisitPolicy>();
            services.AddSingleton<IVisitPolicy, OwnerVisitPolicy>();
            return services;
        }
    }
}
