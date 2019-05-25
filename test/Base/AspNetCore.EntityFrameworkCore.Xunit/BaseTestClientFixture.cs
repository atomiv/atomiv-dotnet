using Microsoft.EntityFrameworkCore;
using Optivem.Test.Xunit;
using System;
using System.Collections.Generic;

namespace Optivem.Test.AspNetCore.EntityFrameworkCore.Xunit
{
    public abstract class BaseTestClientFixture<TClient, TStartup, TDbContext> : BaseTestFixture<TClient>, IDisposable
        where TClient : BaseTestClient<TStartup, TDbContext>
        where TStartup : class
        where TDbContext : DbContext
    {
        public BaseTestClientFixture(TClient fixture) : base(fixture)
        {

        }

        // TODO: VC: Dispose - private and public

        public void Dispose()
        {
            // TODO: VC: Check if possible to truncate all tables?

            // TODO: VC: Optimize
            // Fixture.Client.EnsureDatabaseDeleted();

            Cleanup();
        }

        protected abstract void Cleanup();
    }
}
