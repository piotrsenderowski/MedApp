using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace MedApp.Tests.Unit.Framework
{
    public class ServiceCollectionTests
    {
        [Fact]
        public void test()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IMessenger, Messenger>();
            serviceCollection.AddScoped<IMessenger, Messenger2>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var messenger = serviceProvider.GetRequiredService<IMessenger>();
            messenger.Send();

            var messenger2 = serviceProvider.GetRequiredService<IMessenger>();
            messenger2.Send();

            messenger.ShouldNotBeNull();
            messenger2.ShouldNotBeNull();
            messenger.ShouldBe(messenger2);
            
        }

        private interface IMessenger
        {
            void Send();
        }

        private class Messenger : IMessenger
        {
            private readonly Guid _id = Guid.NewGuid();

            public void Send() => Console.WriteLine($"Sending a message...[{_id})");
        }

        private class Messenger2 : IMessenger
        {
            private readonly Guid _id = Guid.NewGuid();

            public void Send() => Console.WriteLine($"Sending a message...[{_id})");
        }
    }
}
