using Optivem.NorthwindLite.Web.Test.Fixture;
using Optivem.Test.Xunit;
using Optivem.Test.Xunit.AspNetCore;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.NorthwindLite.Web.Test
{
    public class CustomersControllerTest : TestClientFixture<TestClient>
    {
        public CustomersControllerTest(TestClient client) : base(client)
        {
        }

        [Fact]
        public async Task TestListCustomersAsync()
        {
            var actual = await Client.Customers.ListCustomersAsync();

            Assert.NotNull(actual);
        }
    }
}
