using Optivem.Framework.Test.Xunit;
using System;

namespace Optivem.Cli.Core.Application.IntegrationTest.Fixtures
{
    public class ServiceTest : FixtureTest<ServiceFixture>, IDisposable
    {
        public ServiceTest(ServiceFixture fixture)
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
