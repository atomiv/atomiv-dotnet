using Microsoft.Extensions.DependencyInjection;
using Optivem.Template.Core.Application.Customers;
using Optivem.Template.Core.Application.Products;
using Optivem.Template.DependencyInjection;
using Optivem.Template.Infrastructure.EntityFrameworkCore;
using Optivem.Framework.Test.Common.Configuration;
using Optivem.Framework.Test.EntityFrameworkCore;
using System;

namespace Optivem.Template.Core.Application.IntegrationTest.Fixture
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
