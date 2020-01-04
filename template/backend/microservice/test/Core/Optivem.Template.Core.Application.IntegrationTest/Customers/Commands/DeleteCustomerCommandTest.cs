using FluentAssertions;
using Optivem.Framework.Core.Application;
using Optivem.Template.Core.Application.Customers.Commands;
using Optivem.Template.Core.Application.Customers.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Template.Core.Application.IntegrationTest.Customers.Commands
{
    public class DeleteCustomerCommandTest : Test
    {
        public DeleteCustomerCommandTest(Fixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task DeleteCustomer_ValidRequest_ReturnsResponse()
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

            var id = createResponses[1].Id;
            var deleteRequest = new DeleteCustomerCommand { Id = id };
            await Fixture.MessageBus.SendAsync(deleteRequest);

            // Assert

            var findRequest = new FindCustomerQuery { Id = id };
            Func<Task> findFunc = () => Fixture.MessageBus.SendAsync(findRequest);
            await findFunc.Should().ThrowAsync<ExistenceException>();
        }

        [Fact]
        public async Task DeleteCustomer_NotExistRequest_ThrowsNotFoundRequestException()
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

            await CreateCustomersAsync(createRequests);

            // Act

            var id = Guid.NewGuid();
            var deleteRequest = new DeleteCustomerCommand { Id = id };
            Func<Task> deleteFunc = () => Fixture.MessageBus.SendAsync(deleteRequest);

            // Assert

            await deleteFunc.Should().ThrowAsync<ExistenceException>();
        }
    }
}
