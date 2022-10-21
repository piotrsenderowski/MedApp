using MedApp.Application.Abstractions;
using MedApp.Application.Commands;
using MedApp.Core.Repositories;
using MedApp.Infrastructure.DAL.Decorators;
using MedApp.Infrastructure.DAL.Repositories;
using MedApp.Infrastructure.Extensions;
using MedApp.Infrastructure.Logging.Decorators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Infrastructure.DAL
{
    internal static class Extensions
    {
        private const string SectionNameSqlServer = "sqlserver";

        public static IServiceCollection AddSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetOptions<SqlServerOptions>(SectionNameSqlServer);

            services.AddDbContext<MedAppDbContext>(
                option => option.UseSqlServer(options.ConnectionString,
                sso => sso.MigrationsAssembly("MedApp.Infrastructure")));
                //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
                //sso => sso.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)));
            services.AddScoped<IVisitRepository, SqlServerVisitRepository>();
            services.AddScoped<IUserRepository, SqlServerUserRepository>();
            services.AddScoped<IPatientRepository, SqlServerPatientRepository>();
            services.AddHostedService<DatabaseInitializer>();

            services.AddScoped<IUnitOfWork, SqlServerUnitOfWork>();
            services.TryDecorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));
            
            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }
    }
}
