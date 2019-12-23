using Microsoft.Extensions.DependencyInjection;
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

        public ICustomerApplicationService CustomerService => new ServiceProviderWrapper().CustomerService;

        public IOrderService OrderService => new ServiceProviderWrapper().OrderService;

        public IProductApplicationService ProductService => new ServiceProviderWrapper().ProductService;

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

            CustomerService = GetService<ICustomerApplicationService>();
            OrderService = GetService<IOrderService>();
            ProductService = GetService<IProductApplicationService>();
        }

        public DbTestClient<DatabaseContext> Db { get; }

        protected ServiceProvider ServiceProvider { get; }

        protected TService GetService<TService>()
        {
            return ServiceProvider.GetService<TService>();
        }

        public IServiceScope CreateScope()
        {
            return ServiceProvider.CreateScope();
        }

        public ICustomerApplicationService CustomerService { get; }

        public IOrderService OrderService { get; }

        public IProductApplicationService ProductService { get; }
    }
}