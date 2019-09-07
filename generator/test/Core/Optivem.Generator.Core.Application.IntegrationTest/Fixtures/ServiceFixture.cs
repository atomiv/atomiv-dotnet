using Microsoft.Extensions.DependencyInjection;
using Optivem.Generator.DependencyInjection;
using Optivem.Generator.Infrastructure.EntityFrameworkCore;
using Optivem.Framework.Test.EntityFrameworkCore;
using System;
using Optivem.Framework.Test.MicrosoftExtensions.Configuration;
using Optivem.Generator.Core.Application.Customers;
using Optivem.Generator.Core.Application.Products;

namespace Optivem.Generator.Core.Application.IntegrationTest.Fixtures
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
