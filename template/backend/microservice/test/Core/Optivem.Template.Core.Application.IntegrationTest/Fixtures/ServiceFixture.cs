using Microsoft.Extensions.DependencyInjection;
using Optivem.Framework.Core.Application;
using Optivem.Framework.Test.EntityFrameworkCore;
using Optivem.Framework.Test.MicrosoftExtensions.Configuration;
using Optivem.Template.Core.Application.Customers;
using Optivem.Template.Core.Application.Orders;
using Optivem.Template.Core.Application.Products;
using Optivem.Template.DependencyInjection;
using Optivem.Template.Infrastructure.Persistence;
using System;

namespace Optivem.Template.Core.Application.IntegrationTest.Fixtures
{
    public class ServiceFixture : IDisposable
    {
        public ServiceFixture()
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