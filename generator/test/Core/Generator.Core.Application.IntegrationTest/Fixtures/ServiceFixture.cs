using Microsoft.Extensions.DependencyInjection;
using Generator.DependencyInjection;
using Generator.Infrastructure.EntityFrameworkCore;
using Atomiv.Test.EntityFrameworkCore;
using System;
using Atomiv.Test.MicrosoftExtensions.Configuration;
using Generator.Core.Application.Customers;
using Generator.Core.Application.Products;

namespace Generator.Core.Application.IntegrationTest.Fixtures
{
    public class ServiceFixture : IDisposable
    {
        public ServiceFixture()
        {
            var configuration = ConfigurationRootFactory.Create();
            var services = new ServiceCollection();
            services.AddModules(configuration);

            Db = DbTestClientFactory.Create<DatabaseContext>(ConfigurationKeys.DatabaseConnectionKey, e => new DatabaseContext(e));

            ServiceProvider = services.BuildServiceProvider();

            Customers = GetService<ICustomerService>();
            Products = GetService<IProductService>();
        }

        public DbTestClient<DatabaseContext> Db { get; }

        protected ServiceProvider ServiceProvider { get; }

        protected TService GetService<TService>()
        {
            return ServiceProvider.GetService<TService>();
        }

        public ICustomerService Customers { get; }

        public IProductService Products { get; }

        public void Dispose()
        {
            ServiceProvider.Dispose();
        }
    }
}
