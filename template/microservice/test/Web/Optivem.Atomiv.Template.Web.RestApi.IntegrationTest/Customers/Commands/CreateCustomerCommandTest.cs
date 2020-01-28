using FluentAssertions;
using Optivem.Atomiv.Template.Core.Application.Customers.Commands;
using Optivem.Atomiv.Template.Core.Application.Customers.Queries;
using Optivem.Atomiv.Template.Web.RestApi.IntegrationTest.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Atomiv.Template.Web.RestApi.IntegrationTest.Customers.Commands
{
    public class CreateCustomerCommandTest : Test
    {
        public CreateCustomerCommandTest(Fixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task CreateCustomer_ValidRequest_ReturnsResponse()
        {
            // Arrange

            var createRequest = new CreateCustomerCommand
            {
                FirstName = "First name 1",
                LastName = "Last name 1",
            };

            // Act

            var createHttpResponse = await Fixture.Api.Customers.CreateCustomerAsync(createRequest);

            // Assert

            createHttpResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var createResponse = createHttpResponse.Data;

            createResponse.Id.Should().NotBeEmpty();
            createResponse.Should().BeEquivalentTo(createRequest);

            var id = createResponse.Id;
            var findRequest = new FindCustomerQuery { Id = id };
            var findHttpResponse = await Fixture.Api.Customers.FindCustomerAsync(findRequest);
            var findResponse = findHttpResponse.Data;
            findHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            findResponse.Should().BeEquivalentTo(createResponse);
        }

        [Fact]
        public async Task CreateCustomer_InvalidRequest_ThrowsInvalidRequestException()
        {
            // Arrange

            var createRequest = new CreateCustomerCommand
            {
                FirstName = null,
                LastName = "Last name 1",
            };

            // Act

            var createHttpResponse = await Fixture.Api.Customers.CreateCustomerAsync(createRequest);

            // Assert

            createHttpResponse.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        }
    }
}
