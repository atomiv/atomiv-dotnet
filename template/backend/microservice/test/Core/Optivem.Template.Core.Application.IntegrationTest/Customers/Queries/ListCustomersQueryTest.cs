using FluentAssertions;
using Optivem.Template.Core.Application.Customers.Commands;
using Optivem.Template.Core.Application.Customers.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Template.Core.Application.IntegrationTest.Customers.Queries
{
    public class ListCustomersQueryTest : Test
    {
        public ListCustomersQueryTest(Fixture fixture) : base(fixture)
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

            var createResponses = await CreateCustomersAsync(createRequests);

            // Act

            var listRequest = new ListCustomersQuery
            {
                NameSearch = "ark",
                Limit = 10,
            };

            var listResponse = await Fixture.MessageBus.SendAsync(listRequest);

            // Assert

            var expectedRecords = new List<CreateCustomerCommandResponse>
            {
                createResponses[3],
                createResponses[5],
            }
            .Select(e => new ListCustomersRecordResponse
            {
                Id = e.Id,
                Name = $"{e.FirstName} {e.LastName}",
            });

            listResponse.TotalRecords.Should().Be(createRequests.Count);

            listResponse.Records.Should().BeEquivalentTo(expectedRecords);
        }



    }
}
