using FluentAssertions;
using Optivem.Atomiv.Template.Core.Application.Customers.Commands;
using Optivem.Atomiv.Template.Core.Application.Customers.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Atomiv.Template.Web.RestApi.IntegrationTest.Customers.Queries
{
    public class FilterCustomersQueryTest : BaseTest
    {
        public FilterCustomersQueryTest(Fixture fixture) : base(fixture)
        {
        }


        [Fact]
        public async Task ListCustomers_ValidRequest_ReturnsResponse()
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

                new CreateCustomerCommand
                {
                    FirstName = "Markson",
                    LastName = "McDonald",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Jake",
                    LastName = "McDonald",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Mark",
                    LastName = "McPhil",
                },

                new CreateCustomerCommand
                {
                    FirstName = "Susan",
                    LastName = "McDonald",
                },
            };

            var createHttpResponses = await CreateCustomersAsync(createRequests);

            // Act

            var listRequest = new FilterCustomersQuery
            {
                NameSearch = "ark",
                Limit = 10,
            };

            var listHttpResponse = await Fixture.Api.Customers.FilterCustomersAsync(listRequest);

            // Assert

            listHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var expectedRecords = new List<CreateCustomerCommandResponse>
            {
                createHttpResponses[3].Data,
                createHttpResponses[5].Data,
            }
            .Select(e => new ListCustomersRecordResponse
            {
                Id = e.Id,
                Name = $"{e.FirstName} {e.LastName}",
            });

            var listResponse = listHttpResponse.Data;

            listResponse.TotalRecords.Should().Be(createRequests.Count);

            listResponse.Records.Should().BeEquivalentTo(expectedRecords);
        }
    }
}
