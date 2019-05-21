using Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers;
using Optivem.NorthwindLite.Web.Test.Fixture;
using Optivem.Test.Xunit.AspNetCore;
using System.Net;
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

            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);

            var actualContent = actual.Content;

            Assert.NotNull(actualContent);

            // TODO: Test status and header and body
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

            Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

            var createResponseContent = createResponse.Content;

            Assert.True(createResponseContent.Id > 0);

            Assert.Equal(createRequest.FirstName, createResponseContent.FirstName);
            Assert.Equal(createRequest.LastName, createResponseContent.LastName);

            var findResponse = await Client.Customers.FindCustomerAsync(createResponseContent.Id);

            Assert.Equal(HttpStatusCode.OK, findResponse.StatusCode);

            var findResponseContent = findResponse.Content;

            Assert.Equal(createResponseContent.Id, findResponseContent.Id);
            Assert.Equal(createRequest.FirstName, findResponseContent.FirstName);
            Assert.Equal(createRequest.LastName, findResponseContent.LastName);
        }
    }
}