using FluentAssertions;
using Moq;
using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Application.Commands.Handlers.Customers;
using Atomiv.Template.Core.Domain.Customers;
using System.Threading.Tasks;
using Xunit;
using System;
using Atomiv.Core.Application;

namespace Atomiv.Template.Core.Application.UnitTest.Customers.Commands
{
    public class DeleteCustomerCommandTest
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public DeleteCustomerCommandTest()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task HandleAsync_Valid()
        {
            var id = Guid.Parse("926a4480-61f5-416a-a16f-5c722d8463f7");

            var command = new DeleteCustomerCommand
            {
                Id = id,
            };

            var customerId = new CustomerIdentity(id);

            var expectedResponse = new DeleteCustomerCommandResponse();

            _customerRepositoryMock
                .Setup(e => e.ExistsAsync(customerId))
                .ReturnsAsync(true);

            _customerRepositoryMock
                .Setup(e => e.RemoveAsync(customerId));

            var handler = new DeleteCustomerCommandHandler(_customerRepositoryMock.Object,
                _unitOfWorkMock.Object);

            var response = await handler.HandleAsync(command);

            _customerRepositoryMock.Verify(e => e.RemoveAsync(customerId), Times.Once());

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
