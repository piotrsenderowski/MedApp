using MedApp.Application.DTO;
using MedApp.Application.Security;
using MedApp.Infrastructure.Auth;
using MedApp.Infrastructure.DAL;
using MedApp.Infrastructure.Time;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MedApp.Tests.Integration.Controllers
{
    [Collection("api")]
    public abstract class ControlerTests : IClassFixture<OptionsProvider>
    {
        private readonly IAuthenticator _authenticator;
        protected HttpClient Client { get; }
        protected JwtDto Authorize(Guid userId, string role)
        {
            var jwt = _authenticator.CreateToken(userId, role);
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.AccessToken);

            return jwt;
        }

        public ControlerTests(OptionsProvider optionsProvider)
        {
            var authOptions = optionsProvider.Get<AuthOptions>("auth");

            _authenticator = new Authenticator(new OptionsWrapper<AuthOptions>(authOptions), new Clock());
            var app = new MedAppTestApp(ConfigureServices);
            Client = app.Client;
        }

        protected virtual void ConfigureServices(IServiceCollection services)
        {
        }
    }
}
