using Microsoft.Extensions.DependencyInjection;
using Cli.DependencyInjection;
using Cli.Infrastructure.EntityFrameworkCore;
using Atomiv.Test.EntityFrameworkCore;
using System;
using Cli.Core.Application.MyFoos.Services;
using Atomiv.Test.MicrosoftExtensions.Configuration;

namespace Cli.Core.Application.IntegrationTest.Fixtures
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
