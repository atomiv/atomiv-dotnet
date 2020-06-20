using FluentAssertions;
using Moq;
using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Application.Commands.Handlers.Customers;
using Atomiv.Template.Core.Domain.Customers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Atomiv.Template.Core.Application.UnitTest.Customers.Commands
{
    public class DeleteCustomerCommandTest
    {
        [Fact]
        public async Task HandleAsync_Valid()
        {
            var customerRepositoryMock = new Mock<ICustomerRepository>();

            var id = Guid.Parse("926a4480-61f5-416a-a16f-5c722d8463f7");

            var command = new DeleteCustomerCommand
            {
                Id = id,
            };

            var customerId = new CustomerIdentity(id);

            var expectedResponse = new DeleteCustomerCommandResponse();

            customerRepositoryMock
                .Setup(e => e.RemoveAsync(customerId));

            var handler = new DeleteCustomerCommandHandler(customerRepositoryMock.Object);

            var response = await handler.HandleAsync(command);

            customerRepositoryMock.Verify(e => e.RemoveAsync(customerId), Times.Once());

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
