using Optivem.NorthwindLite.Infrastructure.Persistence;
using Optivem.Test.Xunit;
using Optivem.Test.Xunit.AspNetCore.EntityFrameworkCore;

namespace Optivem.NorthwindLite.Web.Test.Fixture
{
    public class TestFixture : BaseTestClientFixture<TestClient, Startup, DatabaseContext>
    {
        public TestFixture(TestClient fixture)
            : base(fixture)
        {
        }
    }
}
