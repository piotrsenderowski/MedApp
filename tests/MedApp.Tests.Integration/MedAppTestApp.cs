using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MedApp.Tests.Integration
{
    internal sealed class MedAppTestApp : WebApplicationFactory<Program>
    {
        public HttpClient Client { get; }
        public MedAppTestApp(Action<IServiceCollection> services)
        {
            Client = WithWebHostBuilder(builder =>
            {
                if(services is not null)
                {
                    builder.ConfigureServices(services);
                }
                builder.UseEnvironment("test");
            }).CreateClient();
        }
    }
}
