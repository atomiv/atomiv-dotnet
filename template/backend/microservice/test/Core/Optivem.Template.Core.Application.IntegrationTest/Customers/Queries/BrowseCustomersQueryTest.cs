using FluentAssertions;
using Optivem.Template.Core.Application.Customers.Commands;
using Optivem.Template.Core.Application.Customers.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Template.Core.Application.IntegrationTest.Customers.Queries
{
    public class BrowseCustomersQueryTest : Test
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

            var createResponses = await CreateCustomersAsync(createRequests);

            // Act

            var browseRequest = new BrowseCustomersQuery
            {
                Page = 2,
                Size = 3,
            };

            var browseResponse = await Fixture.MessageBus.SendAsync(browseRequest);

            // Assert

            var expectedRecordResponses = new List<CreateCustomerCommandResponse>
            {
                createResponses[3],
                createResponses[4],
                createResponses[5],
            };

            browseResponse.TotalRecords.Should().Be(createRequests.Count);

            browseResponse.Records.Should().BeEquivalentTo(expectedRecordResponses);
        }
    }
}
