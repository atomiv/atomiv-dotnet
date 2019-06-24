using Microsoft.EntityFrameworkCore;
using System;

namespace Optivem.Test.Xunit.EntityFrameworkCore
{
    public abstract class BaseTestClientFixture<TClient, TDbContext> : TestFixture<TClient>, IDisposable
        where TClient : DbTestClient<TDbContext>
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
