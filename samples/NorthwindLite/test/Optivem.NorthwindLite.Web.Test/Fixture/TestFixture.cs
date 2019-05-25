using Optivem.NorthwindLite.Infrastructure.Persistence;
using Optivem.Test.AspNetCore.EntityFrameworkCore.Xunit;

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
