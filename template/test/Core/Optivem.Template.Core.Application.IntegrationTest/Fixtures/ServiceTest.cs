using Optivem.Framework.Test.Xunit;
using System;

namespace Optivem.Template.Core.Application.IntegrationTest.Fixtures
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
                context.CustomerRecords.RemoveRange(context.CustomerRecords);
                context.ProductRecords.RemoveRange(context.ProductRecords);
                context.SaveChanges();
            }
        }
    }
}