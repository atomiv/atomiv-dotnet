using Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers;
using Optivem.NorthwindLite.Web.Test.Fixture;
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
        public async Task TestListCustomers_RequestValid_ResponseOk()
        {
            var actual = await Client.Customers.ListCustomersAsync();

            Assert.NotNull(actual);
        }

        [Fact]
        public async Task TestCreateCustomer_RequestValid_ResponseCreated()
        {
            var createRequest = new CreateCustomerRequest
            {
                FirstName = "First name 1",
                LastName = "Last name 1",
            };

            var createResponse = await Client.Customers.CreateCustomerAsync(createRequest);

            Assert.True(createResponse.Id > 0);

            Assert.Equal(createRequest.FirstName, createResponse.FirstName);
            Assert.Equal(createRequest.LastName, createResponse.LastName);

            var findResponse = await Client.Customers.FindCustomerAsync(createResponse.Id);

            Assert.Equal(createResponse.Id, findResponse.Id);
            Assert.Equal(createRequest.FirstName, findResponse.FirstName);
            Assert.Equal(createRequest.LastName, findResponse.LastName);

        }
    }
}
