using Optivem.NorthwindLite.Core.Application.Interface.Requests.Customers;
using Optivem.NorthwindLite.Web.Test.Fixture;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.NorthwindLite.Web.Test
{
    public class CustomersControllerTest : TestFixture
    {
        public CustomersControllerTest(TestClient client) : base(client)
        {

        }

        [Fact]
        public async Task TestListCustomers_ResponseOK()
        {
            /*
            var samples = new List<Customer>
            {
                new Customer
                {
                    FirstName = "Mary",
                    LastName = "Smith",                    
                },

                new Customer
                {
                    FirstName = "John",
                    LastName = "McDonald",
                }
            };

            Add();

            using(var context = Client.CreateContext())
            {
                var repository = unitOfWork.GetRepository<>
            }
            */

            var actual = await Fixture.Customers.ListCustomersAsync();

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

            var createResponse = await Fixture.Customers.CreateCustomerAsync(createRequest);

            Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

            var createResponseContent = createResponse.Content;

            Assert.True(createResponseContent.Id > 0);

            Assert.Equal(createRequest.FirstName, createResponseContent.FirstName);
            Assert.Equal(createRequest.LastName, createResponseContent.LastName);

            var findResponse = await Fixture.Customers.FindCustomerAsync(createResponseContent.Id);

            Assert.Equal(HttpStatusCode.OK, findResponse.StatusCode);

            var findResponseContent = findResponse.Content;

            Assert.Equal(createResponseContent.Id, findResponseContent.Id);
            Assert.Equal(createRequest.FirstName, findResponseContent.FirstName);
            Assert.Equal(createRequest.LastName, findResponseContent.LastName);
        }

        [Fact]
        public async Task TestCreateCustomer_RequestInvalid_ResponseUnprocessableEntity()
        {
            var createRequest = new CreateCustomerRequest
            {
                FirstName = null,
                LastName = "Last name 1",
            };

            var createResponse = await Fixture.Customers.CreateCustomerAsync(createRequest);

            Assert.Equal(HttpStatusCode.UnprocessableEntity, createResponse.StatusCode);

            var createResponseContent = createResponse.Content;

            var problemDetails = createResponse.ProblemDetails;

            Assert.Equal((int)HttpStatusCode.UnprocessableEntity, problemDetails.Status);
        }

        [Fact]
        public async Task Test3()
        {
            await RunInner();
        }

        [Fact]
        public async Task Test4()
        {
            await RunInner();
        }

        [Fact]
        public async Task Test5()
        {
            await RunInner();
        }

        [Fact]
        public async Task Test6()
        {
            await RunInner();
        }

        [Fact]
        public async Task Test7()
        {
            await RunInner();
        }

        private async Task RunInner()
        {
            var createRequest = new CreateCustomerRequest
            {
                FirstName = "First name 1",
                LastName = "Last name 1",
            };

            var createResponse = await Fixture.Customers.CreateCustomerAsync(createRequest);

            Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

            var createResponseContent = createResponse.Content;

            Assert.True(createResponseContent.Id > 0);

            Assert.Equal(createRequest.FirstName, createResponseContent.FirstName);
            Assert.Equal(createRequest.LastName, createResponseContent.LastName);

            var findResponse = await Fixture.Customers.FindCustomerAsync(createResponseContent.Id);

            Assert.Equal(HttpStatusCode.OK, findResponse.StatusCode);

            var findResponseContent = findResponse.Content;

            Assert.Equal(createResponseContent.Id, findResponseContent.Id);
            Assert.Equal(createRequest.FirstName, findResponseContent.FirstName);
            Assert.Equal(createRequest.LastName, findResponseContent.LastName);
        }

    }
}