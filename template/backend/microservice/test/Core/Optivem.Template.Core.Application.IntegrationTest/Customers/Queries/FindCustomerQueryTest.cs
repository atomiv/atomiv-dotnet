using FluentAssertions;
using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Customers.Commands;
using Optivem.Template.Core.Application.Customers.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Template.Core.Application.IntegrationTest.Customers.Queries
{
    public class FindCustomerQueryTest : Test
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

            var createResponses = await CreateCustomersAsync(createRequests);

            // Act

            var someCreateResponse = createResponses[1];
            var id = someCreateResponse.Id;
            var findRequest = new FindCustomerQuery { Id = id };
            var findResponse = await Fixture.MessageBus.SendAsync(findRequest);

            // Assert

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
            Func<Task> findFunc = () => Fixture.MessageBus.SendAsync(findRequest);

            // Assert

            await findFunc.Should().ThrowAsync<ExistenceException>();
        }
    }
}
