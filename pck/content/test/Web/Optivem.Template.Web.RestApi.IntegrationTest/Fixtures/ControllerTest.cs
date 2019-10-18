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
            using (var context = Fixture.Db.CreateContext())
            {
                context.CustomerRecords.RemoveRange(context.CustomerRecords);
                context.ProductRecords.RemoveRange(context.ProductRecords);
                context.SaveChanges();
            }
        }
    }
}