using Optivem.Template.Infrastructure.EntityFrameworkCore;
using Optivem.Test.Xunit;
using System;

namespace Optivem.Template.Web.Test.Fixture
{
    public class ControllerTest : FixtureTest<ControllerFixture>, IDisposable
    {
        public ControllerTest(ControllerFixture fixture)
            : base(fixture)
        {
        }

        public void Dispose()
        {
            // TODO: VC: Optimize, use truncate, also generic truncate for all DB contexts, but only the operational tables

            using (var context = Fixture.Db.CreateContext())
            {
                context.Customer.RemoveRange(context.Customer);
                context.Product.RemoveRange(context.Product);
                context.SaveChanges();
            }
        }
    }
}
