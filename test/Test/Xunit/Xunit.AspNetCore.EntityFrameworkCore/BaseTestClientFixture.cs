using Microsoft.EntityFrameworkCore;
using Optivem.Test.Xunit;
using System;

namespace Optivem.Test.AspNetCore.EntityFrameworkCore.Xunit
{
    public abstract class BaseTestClientFixture<TClient, TStartup, TDbContext> : BaseTestFixture<TClient>, IDisposable
        where TClient : BaseTestClient<TStartup, TDbContext>
        where TStartup : class
        where TDbContext : DbContext
    {
        public BaseTestClientFixture(TClient fixture) : base(fixture)
        {
            Startup();
        }

        // TODO: VC: Dispose - private and public

        public void Dispose()
        {
            // TODO: VC: Check if possible to truncate all tables?

            // TODO: VC: Optimize
            // Fixture.Client.EnsureDatabaseDeleted();

            Cleanup();
        }

        protected virtual void Startup()
        {
            // NOTE: By default nothing
        }

        protected abstract void Cleanup();
    }
}
