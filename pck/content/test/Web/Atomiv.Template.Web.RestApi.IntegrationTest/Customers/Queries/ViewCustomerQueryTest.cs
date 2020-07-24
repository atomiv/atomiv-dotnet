using FluentAssertions;
using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Application.Queries.Customers;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using System;

namespace Atomiv.Template.Web.RestApi.IntegrationTest.Customers.Queries
{
    public class ViewCustomerQueryTest : BaseTest
    {
        public ViewCustomerQueryTest(Fixture fixture) : base(fixture)
        {
        }


        [Fact]
        public async Task ViewCustomer_ValidRequest_ReturnsCustomer()
        {
            // Arrange

            var header = await GetDefaultHeaderDataAsync();

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
            var findRequest = new ViewCustomerQuery { Id = id };
            var findHttpResponse = await Fixture.Api.Customers.ViewCustomerAsync(findRequest, header);

            // Assert

            findHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var findResponse = findHttpResponse.Data;

            findResponse.Should().BeEquivalentTo(someCreateResponse);
        }


        [Fact]
        public async Task ViewCustomer_NotExistRequest_ThrowsNotFoundRequestException()
        {
            // Arrange

            var header = await GetDefaultHeaderDataAsync();

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
            var findRequest = new ViewCustomerQuery { Id = id };
            var findHttpResponse = await Fixture.Api.Customers.ViewCustomerAsync(findRequest, header);

            // Assert

            findHttpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
