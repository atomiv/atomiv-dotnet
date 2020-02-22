using FluentAssertions;
using Optivem.Atomiv.Template.Core.Application.Customers.Commands;
using Optivem.Atomiv.Template.Core.Application.Customers.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Atomiv.Template.Web.RestApi.IntegrationTest.Customers.Queries
{
    public class BrowseCustomersQueryTest : BaseTest
    {
        public BrowseCustomersQueryTest(Fixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task BrowseCustomers_ValidRequest_ReturnsResponse()
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

            var browseRequest = new BrowseCustomersQuery
            {
                Page = 2,
                Size = 3,
            };

            var browseHttpResponse = await Fixture.Api.Customers.BrowseCustomersAsync(browseRequest);

            // Assert

            var expectedRecordResponses = new List<CreateCustomerCommandResponse>
            {
                createHttpResponses[3].Data,
                createHttpResponses[4].Data,
                createHttpResponses[5].Data,
            };

            browseHttpResponse.Data.TotalRecords.Should().Be(createRequests.Count);

            browseHttpResponse.Data.Records.Should().BeEquivalentTo(expectedRecordResponses);
        }
    }
}
