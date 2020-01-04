using Optivem.Framework.Test.Xunit;
using System;

namespace Optivem.Template.Web.RestApi.IntegrationTest.Fixtures
{
    public class ControllerTest : FixtureTest<ControllerFixture>, IDisposable
    {
        public ControllerTest(ControllerFixture fixture)
            : base(fixture)
        {
        }

        public void Dispose()
        {
            /*

            using (var context = Fixture.Db.CreateContext())
            {
                context.Customers.RemoveRange(context.Customers);
                context.Products.RemoveRange(context.Products);
                context.SaveChanges();
            }

            */
        }
    }
}