using Microsoft.Extensions.DependencyInjection;
using Optivem.Cli.DependencyInjection;
using Optivem.Cli.Infrastructure.EntityFrameworkCore;
using Optivem.Framework.Test.EntityFrameworkCore;
using System;
using Optivem.Cli.Core.Application.MyFoos.Services;
using Optivem.Framework.Test.MicrosoftExtensions.Configuration;

namespace Optivem.Cli.Core.Application.IntegrationTest.Fixtures
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

            MyFoos = GetService<IMyFooService>();
        }

        public DbTestClient<DatabaseContext> Db { get; }

        protected ServiceProvider ServiceProvider { get; }

        protected TService GetService<TService>()
        {
            return ServiceProvider.GetService<TService>();
        }

        public IMyFooService MyFoos { get; }

        public void Dispose()
        {
            ServiceProvider.Dispose();
        }
    }
}
