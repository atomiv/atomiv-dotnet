using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Atomiv.Template.DependencyInjection;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using System;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.IntegrationTest
{
    public class Fixture : IDisposable
    {
        private readonly ServiceProvider _serviceProvider;

        public Fixture()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Test.json");

            var configuration = configurationBuilder.Build();

            var services = new ServiceCollection();
            services.AddModules(configuration);

            _serviceProvider = services.BuildServiceProvider();

            var databaseContext = _serviceProvider.GetRequiredService<DatabaseContext>();

            databaseContext.Database.Migrate();
        }

        public IServiceScope CreateScope()
        {
            return _serviceProvider.CreateScope();
        }

        public TService GetService<TService>()
        {
            return _serviceProvider.GetRequiredService<TService>();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Fixture()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}
