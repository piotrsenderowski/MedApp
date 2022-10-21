using MedApp.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedApp.Tests.Integration
{
    public class OptionsProvider
    {
        private readonly IConfiguration _configuration;

        public OptionsProvider()
        {
            _configuration = GetConfigurationRoot();
        }

        public T Get<T>(string sectionName) where T : class, new() => _configuration.GetOptions<T>(sectionName);

        private static IConfigurationRoot GetConfigurationRoot()
            => new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json", true)
                .AddEnvironmentVariables()
                .Build();
    }
}
