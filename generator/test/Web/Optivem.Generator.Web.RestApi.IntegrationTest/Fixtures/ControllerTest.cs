using Optivem.Atomiv.Test.Xunit;
using System;

namespace Optivem.Generator.Web.RestApi.IntegrationTest.Fixtures
{
    public class ControllerTest : FixtureTest<ControllerFixture>, IDisposable
    {
        public ControllerTest(ControllerFixture fixture)
            : base(fixture)
        {
        }

        public void Dispose()
        {
            using (var context = Fixture.Db.CreateContext())
            {
                context.Customer.RemoveRange(context.Customer);
                context.Product.RemoveRange(context.Product);
                context.SaveChanges();
            }
        }
    }
}
