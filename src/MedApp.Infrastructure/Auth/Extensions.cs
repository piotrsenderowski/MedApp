using MedApp.Application.Security;
using MedApp.Infrastructure.DAL;
using MedApp.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Infrastructure.Auth
{
    internal static class Extensions
    {
        private const string SectionName = "auth";
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthOptions>(configuration.GetRequiredSection(SectionName));
            var options = configuration.GetOptions<AuthOptions>(SectionName);

            services
                .AddSingleton<IAuthenticator, Authenticator>()
                .AddSingleton<ITokenStorage, HttpContextTokenStorage>()
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.Audience = options.Audience;
                    x.IncludeErrorDetails = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = options.Issuer,
                        ClockSkew = TimeSpan.Zero,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SigningKey))
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("is-admin", policy =>
                {
                    policy.RequireRole("admin");
                });
                //options.AddPolicy("is-doctor", policy =>
                //{
                //    policy.RequireRole("doctor");
                //});
                //options.AddPolicy("is-assistant", policy =>
                //{
                //    policy.RequireRole("assistant");
                //});
            });

            return services;
        }
    }
}
