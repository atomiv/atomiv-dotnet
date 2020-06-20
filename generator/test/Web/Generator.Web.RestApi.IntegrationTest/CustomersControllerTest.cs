using Generator.Core.Application.Customers.Requests;
using Generator.Infrastructure.EntityFrameworkCore.Customers.Records;
using Generator.Web.RestApi.IntegrationTest.Fixtures;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Generator.Web.RestApi.IntegrationTest
{
    public class CustomersControllerTest : ControllerTest
    {
        private List<CustomerRecord> _customerRecords;

        public CustomersControllerTest(ControllerFixture fixture) : base(fixture)
        {
            _customerRecords = new List<CustomerRecord>
            {
                new CustomerRecord
                {
                    FirstName = "Mary",
                    LastName = "Smith",
                },

                new CustomerRecord
                {
                    FirstName = "John",
                    LastName = "McDonald",
                }
            };

            Fixture.Db.AddRange(_customerRecords);
        }

        [Fact]
        public async Task ListCustomers_OK()
        {
            var listRequest = new ListCustomersRequest { };

            var actual = await Fixture.Api.Customers.ListCustomersAsync(listRequest);

            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);

            var actualContent = actual.Data;

            Assert.Equal(2, actualContent.Records.Count);

            var expectedFirst = _customerRecords[0];
            var actualFirst = actualContent.Records[0];

            Assert.True(actualFirst.Id > 0);
            Assert.Equal(expectedFirst.FirstName, actualFirst.FirstName);
            Assert.Equal(expectedFirst.LastName, actualFirst.LastName);

            var expectedSecond = _customerRecords[1];
            var actualSecond = actualContent.Records[1];

            Assert.True(actualSecond.Id > 0);
            Assert.Equal(expectedSecond.FirstName, actualSecond.FirstName);
            Assert.Equal(expectedSecond.LastName, actualSecond.LastName);
        }

        [Fact]
        public async Task FindCustomer_Valid_OK()
        {
            var customerRecord = _customerRecords[0];
            var id = customerRecord.Id;

            var findRequest = new FindCustomerRequest { Id = id };

            var findResponse = await Fixture.Api.Customers.FindCustomerAsync(findRequest);

            Assert.Equal(HttpStatusCode.OK, findResponse.StatusCode);

            var findResponseContent = findResponse.Data;

            Assert.Equal(customerRecord.Id, findResponseContent.Id);
            Assert.Equal(customerRecord.FirstName, findResponseContent.FirstName);
            Assert.Equal(customerRecord.LastName, findResponseContent.LastName);
        }

        [Fact]
        public async Task FindCustomer_NotExist_NotFound()
        {
            var id = 999;

            var findRequest = new FindCustomerRequest { Id = id };

            var findResponse = await Fixture.Api.Customers.FindCustomerAsync(findRequest);

            Assert.Equal(HttpStatusCode.NotFound, findResponse.StatusCode);
        }

        [Fact]
        public async Task CreateCustomer_Valid_Created()
        {
            var createRequest = new CreateCustomerRequest
            {
                FirstName = "First name 1",
                LastName = "Last name 1",
            };

            var createResponse = await Fixture.Api.Customers.CreateCustomerAsync(createRequest);

            Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

            var createResponseContent = createResponse.Data;

            Assert.True(createResponseContent.Id > 0);

            Assert.Equal(createRequest.FirstName, createResponseContent.FirstName);
            Assert.Equal(createRequest.LastName, createResponseContent.LastName);

            var findRequest = new FindCustomerRequest { Id = createResponseContent.Id };

            var findResponse = await Fixture.Api.Customers.FindCustomerAsync(findRequest);

            Assert.Equal(HttpStatusCode.OK, findResponse.StatusCode);

            var findResponseContent = findResponse.Data;

            Assert.Equal(createResponseContent.Id, findResponseContent.Id);
            Assert.Equal(createRequest.FirstName, findResponseContent.FirstName);
            Assert.Equal(createRequest.LastName, findResponseContent.LastName);
        }

        [Fact]
        public async Task CreateCustomer_Invalid_UnprocessableEntity()
        {
            var createRequest = new CreateCustomerRequest
            {
                FirstName = null,
                LastName = "Last name 1",
            };

            var createResponse = await Fixture.Api.Customers.CreateCustomerAsync(createRequest);

            Assert.Equal(HttpStatusCode.UnprocessableEntity, createResponse.StatusCode);

            var createResponseContent = createResponse.Data;

            var problemDetails = createResponse.ProblemDetails;

            Assert.Equal((int)HttpStatusCode.UnprocessableEntity, problemDetails.Status);
        }

        [Fact]
        public async Task UpdateCustomer_Valid_OK()
        {
            var customerRecord = _customerRecords[0];

            var updateRequest = new UpdateCustomerRequest
            {
                Id = customerRecord.Id,
                FirstName = "New first name",
                LastName = "New last name",
            };

            var updateResponse = await Fixture.Api.Customers.UpdateCustomerAsync(updateRequest);

            Assert.Equal(HttpStatusCode.OK, updateResponse.StatusCode);

            var updateResponseContent = updateResponse.Data;

            Assert.Equal(updateRequest.Id, updateResponseContent.Id);
            Assert.Equal(updateRequest.FirstName, updateResponseContent.FirstName);
            Assert.Equal(updateRequest.LastName, updateResponseContent.LastName);
        }

        [Fact]
        public async Task UpdateCustomer_NotExist_NotFound()
        {
            var customerRecord = _customerRecords[0];

            var updateRequest = new UpdateCustomerRequest
            {
                Id = 999,
                FirstName = "New first name",
                LastName = "New last name",
            };

            var updateResponse = await Fixture.Api.Customers.UpdateCustomerAsync(updateRequest);

            Assert.Equal(HttpStatusCode.NotFound, updateResponse.StatusCode);
        }

        [Fact]
        public async Task UpdateCustomer_Invalid_UnprocessableEntity()
        {
            var customerRecord = _customerRecords[0];

            var updateRequest = new UpdateCustomerRequest
            {
                Id = customerRecord.Id,
                FirstName = "New first name",
                LastName = null,
            };

            var updateResponse = await Fixture.Api.Customers.UpdateCustomerAsync(updateRequest);
            Assert.Equal(HttpStatusCode.UnprocessableEntity, updateResponse.StatusCode);

            var problemDetails = updateResponse.ProblemDetails;
            Assert.Equal((int)HttpStatusCode.UnprocessableEntity, problemDetails.Status);
        }

        [Fact]
        public async Task DeleteCustomer_Valid_OK()
        {
            var customerRecord = _customerRecords[0];
            var id = customerRecord.Id;

            var deleteRequest = new DeleteCustomerRequest { Id = id };

            var deleteResponse = await Fixture.Api.Customers.DeleteCustomerAsync(deleteRequest);

            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
        }

        [Fact]
        public async Task DeleteCustomer_NotExist_NotFound()
        {
            var id = 999;

            var deleteRequest = new DeleteCustomerRequest { Id = id };

            var deleteResponse = await Fixture.Api.Customers.DeleteCustomerAsync(deleteRequest);

            Assert.Equal(HttpStatusCode.NotFound, deleteResponse.StatusCode);
        }
    }
}