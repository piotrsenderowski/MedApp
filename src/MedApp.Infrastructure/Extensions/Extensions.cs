using MedApp.Application.Abstractions;
using MedApp.Core.Abstractions;
using MedApp.Core.Repositories;
using MedApp.Infrastructure.Auth;
using MedApp.Infrastructure.DAL;
using MedApp.Infrastructure.DAL.Repositories;
using MedApp.Infrastructure.Exceptions;
using MedApp.Infrastructure.Logging;
using MedApp.Infrastructure.Security;
using MedApp.Infrastructure.Time;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Infrastructure.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("app");
            services.Configure<AppOptions>(section);
            services.AddSingleton<ExceptionMiddleware>();
            services.AddSecurity();
            services.AddAuth(configuration);
            services.AddHttpContextAccessor();

            services
                .AddSqlServer(configuration)
                .AddSingleton<IClock, Clock>();

            var infrastructureAssembly = typeof(AppOptions).Assembly;

            services.Scan(s => s.FromAssemblies(infrastructureAssembly)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.AddCustomLogging();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(swagger =>
            {
                swagger.EnableAnnotations();
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MedApp API",
                    Version = "v1"
                });
            });

            return services;
        }

        public static WebApplication UseInfrastructure(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSwagger();
            app.UseReDoc(reDoc =>
            {
                reDoc.RoutePrefix = "docs";
                reDoc.DocumentTitle = "MySpot API";
                reDoc.SpecUrl("/swagger/v1/swagger.json");
            });
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }

        public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
        {
            var options = new T();
            var section = configuration.GetSection(sectionName);
            section.Bind(options);

            return options;
        }
    }
}
