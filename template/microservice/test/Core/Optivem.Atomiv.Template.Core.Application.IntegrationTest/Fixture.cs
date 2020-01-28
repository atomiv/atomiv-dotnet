using Microsoft.Extensions.DependencyInjection;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Test.EntityFrameworkCore;
using Optivem.Atomiv.Test.MicrosoftExtensions.Configuration;
using Optivem.Atomiv.Template.DependencyInjection;
using Optivem.Atomiv.Template.Infrastructure.Persistence;
using System;

namespace Optivem.Atomiv.Template.Core.Application.IntegrationTest
{
    public class Fixture : IDisposable
    {
        public Fixture()
        {

        }

        public DbTestClient<DatabaseContext> Db => new ServiceProviderWrapper().Db;

        public IMessageBus MessageBus => new ServiceProviderWrapper().MessageBus;

        public void Dispose()
        {
            // ServiceProvider.Dispose();
        }
    }

    public class ServiceProviderWrapper
    {
        public ServiceProviderWrapper()
        {
            var configuration = ConfigurationRootFactory.Create();
            var services = new ServiceCollection();
            services.AddModules(configuration);

            Db = DbTestClientFactory.Create<DatabaseContext>(ConfigurationKeys.DatabaseConnectionKey, e => new DatabaseContext(e), ConfigurationKeys.SqlServerOptionsAction);

            ServiceProvider = services.BuildServiceProvider();

            MessageBus = GetService<IMessageBus>();
        }

        public DbTestClient<DatabaseContext> Db { get; }

        protected ServiceProvider ServiceProvider { get; }

        protected TService GetService<TService>()
        {
            return ServiceProvider.GetService<TService>();
        }

        public IMessageBus MessageBus { get; }

        public IServiceScope CreateScope()
        {
            return ServiceProvider.CreateScope();
        }
    }
}