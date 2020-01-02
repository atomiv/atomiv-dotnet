using FluentAssertions;
using Optivem.Framework.Test.Xunit;
using Optivem.Template.Core.Application.Customers.Commands;
using Optivem.Template.Core.Application.Customers.Queries;
using Optivem.Template.Infrastructure.Persistence.Records;
using Optivem.Template.Web.RestApi.IntegrationTest.Fixtures;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Template.Web.RestApi.IntegrationTest
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
                    Id = SequentialGuid.SequentialSqlGuidGenerator.Instance.NewGuid(),
                    FirstName = "Mary",
                    LastName = "Smith",
                },

                new CustomerRecord
                {
                    Id = SequentialGuid.SequentialSqlGuidGenerator.Instance.NewGuid(),
                    FirstName = "John",
                    LastName = "McDonald",
                }
            };

            Fixture.Db.AddRange(_customerRecords);
        }

        [Fact(Skip = "In progress")]
        public async Task ListCustomers_OK()
        {
            var listRequest = new ListCustomersQuery { };

            var listHttpResponse = await Fixture.Api.Customers.ListCustomersAsync(listRequest);

            listHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var listResponse = listHttpResponse.Data;

            listResponse.Records.Count.Should().Be(2);

            var expectedFirst = _customerRecords[0];
            var actualFirst = listResponse.Records[0];

            actualFirst.Id.Should().NotBeEmpty();

            actualFirst.Name.Should().Be(expectedFirst.FirstName + " " + expectedFirst.LastName);

            var expectedSecond = _customerRecords[1];
            var actualSecond = listResponse.Records[1];

            actualSecond.Id.Should().NotBeEmpty();

            actualSecond.Name.Should().Be(expectedSecond.FirstName + " " + expectedSecond.LastName);
        }

        [Fact]
        public async Task FindCustomer_Valid_OK()
        {
            var customerRecord = _customerRecords[0];
            var id = customerRecord.Id;

            var findRequest = new FindCustomerQuery { Id = id };

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
            var id = Guid.NewGuid();

            var findRequest = new FindCustomerQuery { Id = id };

            var findResponse = await Fixture.Api.Customers.FindCustomerAsync(findRequest);

            Assert.Equal(HttpStatusCode.NotFound, findResponse.StatusCode);
        }

        [Fact]
        public async Task CreateCustomer_Valid_Created()
        {
            var createRequest = new CreateCustomerCommand
            {
                FirstName = "First name 1",
                LastName = "Last name 1",
            };

            var createResponse = await Fixture.Api.Customers.CreateCustomerAsync(createRequest);

            Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

            var createResponseContent = createResponse.Data;

            AssertUtilities.NotEmpty(createResponseContent.Id);

            Assert.Equal(createRequest.FirstName, createResponseContent.FirstName);
            Assert.Equal(createRequest.LastName, createResponseContent.LastName);

            var findRequest = new FindCustomerQuery { Id = createResponseContent.Id };

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
            var createRequest = new CreateCustomerCommand
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

            var updateRequest = new UpdateCustomerCommand
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
            var id = Guid.NewGuid();

            var updateRequest = new UpdateCustomerCommand
            {
                Id = id,
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

            var updateRequest = new UpdateCustomerCommand
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

            var deleteRequest = new DeleteCustomerCommand { Id = id };

            var deleteResponse = await Fixture.Api.Customers.DeleteCustomerAsync(deleteRequest);

            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
        }

        [Fact]
        public async Task DeleteCustomer_NotExist_NotFound()
        {
            var id = Guid.NewGuid();

            var deleteRequest = new DeleteCustomerCommand { Id = id };

            var deleteResponse = await Fixture.Api.Customers.DeleteCustomerAsync(deleteRequest);

            Assert.Equal(HttpStatusCode.NotFound, deleteResponse.StatusCode);
        }
    }
}