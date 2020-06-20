using Atomiv.Test.Xunit;
using System;

namespace Cli.Web.RestApi.IntegrationTest.Fixtures
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
                context.MyFoos.RemoveRange(context.MyFoos);
                context.SaveChanges();
            }
        }
    }
}
