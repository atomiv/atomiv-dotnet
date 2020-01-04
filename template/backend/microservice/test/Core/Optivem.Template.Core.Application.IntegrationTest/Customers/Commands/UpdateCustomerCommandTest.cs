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
    public class UpdateCustomerCommandTest : Test
    {
        public UpdateCustomerCommandTest(Fixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task UpdateCustomer_ValidRequest_ReturnsResponse()
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

            var updateRequest = new UpdateCustomerCommand
            {
                Id = someCreateResponse.Id,
                FirstName = "New first name",
                LastName = "New last name",
            };

            var updateResponse = await Fixture.MessageBus.SendAsync(updateRequest);

            // Assert

            updateResponse.Should().BeEquivalentTo(updateRequest);

            var id = updateRequest.Id;
            var findRequest = new FindCustomerQuery { Id = id };
            var findResponse = await Fixture.MessageBus.SendAsync(findRequest);
            findResponse.Should().BeEquivalentTo(updateResponse);
        }

        [Fact]
        public async Task UpdateCustomer_NotExistRequest_ThrowsNotFoundRequestException()
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

            var updateRequest = new UpdateCustomerCommand
            {
                Id = id,
                FirstName = "New first name",
                LastName = "New last name",
            };

            Func<Task> updateFunc = () => Fixture.MessageBus.SendAsync(updateRequest);

            // Assert

            await updateFunc.Should().ThrowAsync<ExistenceException>();
        }

        [Fact]
        public async Task UpdateCustomer_InvalidRequest_ThrowsInvalidRequestException()
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

            var someCreateResponse = createResponses[2];

            var updateRequest = new UpdateCustomerCommand
            {
                Id = someCreateResponse.Id,
                FirstName = "New first name",
                LastName = null,
            };

            Func<Task> updateFunc = () => Fixture.MessageBus.SendAsync(updateRequest);

            // Assert

            await updateFunc.Should().ThrowAsync<ValidationException>();
        }
    }
}
