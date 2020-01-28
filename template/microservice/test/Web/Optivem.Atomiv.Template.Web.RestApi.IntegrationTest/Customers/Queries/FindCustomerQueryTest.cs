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

namespace Optivem.Atomiv.Template.Web.RestApi.IntegrationTest.Customers.Queries
{
    public class FindCustomerQueryTest : BaseTest
    {
        public FindCustomerQueryTest(Fixture fixture) : base(fixture)
        {
        }


        [Fact]
        public async Task FindCustomer_ValidRequest_ReturnsCustomer()
        {
            // Arrange

            var createRequests = new List<CreateCustomerCommand>
            {
                new CreateCustomerCommand
                {
                    FirstName = "Mary",
                    LastName = "Smith",
                },

                new CreateCustomerCommand
                {
                    FirstName = "John",
                    LastName = "McDonald",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Rob",
                    LastName = "McDonald",
                },
            };

            var createHttpResponses = await CreateCustomersAsync(createRequests);

            // Act

            var someCreateResponse = createHttpResponses[1].Data;
            var id = someCreateResponse.Id;
            var findRequest = new FindCustomerQuery { Id = id };
            var findHttpResponse = await Fixture.Api.Customers.FindCustomerAsync(findRequest);

            // Assert

            findHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var findResponse = findHttpResponse.Data;

            findResponse.Should().BeEquivalentTo(someCreateResponse);
        }


        [Fact]
        public async Task FindCustomer_NotExistRequest_ThrowsNotFoundRequestException()
        {
            // Arrange

            var createRequests = new List<CreateCustomerCommand>
            {
                new CreateCustomerCommand
                {
                    FirstName = "Mary",
                    LastName = "Smith",
                },

                new CreateCustomerCommand
                {
                    FirstName = "John",
                    LastName = "McDonald",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Rob",
                    LastName = "McDonald",
                },
            };

            var createResponses = await CreateCustomersAsync(createRequests);

            // Act

            var id = Guid.NewGuid();
            var findRequest = new FindCustomerQuery { Id = id };
            var findHttpResponse = await Fixture.Api.Customers.FindCustomerAsync(findRequest);

            // Assert

            findHttpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
