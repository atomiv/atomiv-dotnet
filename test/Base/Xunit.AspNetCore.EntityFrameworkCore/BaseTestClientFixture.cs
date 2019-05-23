using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Test.Xunit.AspNetCore.EntityFrameworkCore
{
    public class BaseTestClientFixture<TFixture, TStartup, TDbContext> : BaseTestFixture<TFixture>
        where TFixture : BaseTestClient<TStartup, TDbContext>
        where TStartup : class
        where TDbContext : DbContext
    {
        public BaseTestClientFixture(TFixture fixture) 
            : base(fixture)
        {
        }

        protected override void Setup()
        {
            using (var context = Fixture.CreateDbContext())
            {
                context.Database.EnsureCreated();
            }
        }

        protected override void Teardown()
        {
            using (var context = Fixture.CreateDbContext())
            {
                context.Database.EnsureDeleted();
            }
        }

        // TODO: VC: Perhaps setup sequential here, due to DB? Or as flag
    }
}
