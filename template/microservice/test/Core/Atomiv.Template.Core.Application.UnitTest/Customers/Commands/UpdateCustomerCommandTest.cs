using FluentAssertions;
using Moq;
using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Application.Commands.Handlers.Customers;
using Atomiv.Template.Core.Domain.Customers;
using System.Threading.Tasks;
using Xunit;
using System;

namespace Atomiv.Template.Core.Application.UnitTest.Customers.Commands
{
    public class UpdateCustomerCommandTest
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;

        public UpdateCustomerCommandTest()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task HandleAsync_Valid()
        {
            var id = Guid.Parse("926a4480-61f5-416a-a16f-5c722d8463f7");

            var command = new EditCustomerCommand
            {
                Id = id,
                FirstName = "Mary 2",
                LastName = "Smith 2",
            };

            var customerId = new CustomerIdentity(id);
            var referenceNumber = new CustomerReferenceNumber(DateTime.Now, "ABC12");
            var customer = new Customer(customerId, referenceNumber, "Mary", "Smith");

            var updatedCustomer = new Customer(customerId, referenceNumber, "Mary 2", "Smith 2");

            var expectedResponse = new EditCustomerCommandResponse
            {
                Id = id,
                FirstName = "Mary 2",
                LastName = "Smith 2",
            };

            _customerRepositoryMock
                .Setup(e => e.FindAsync(customerId))
                .ReturnsAsync(customer);

            _customerRepositoryMock
                .Setup(e => e.UpdateAsync(updatedCustomer));

            _mapperMock
                .Setup(e => e.Map<Customer, EditCustomerCommandResponse>(updatedCustomer))
                .Returns(expectedResponse);

            var handler = new EditCustomerCommandHandler(_customerRepositoryMock.Object,
                _unitOfWorkMock.Object,
                _mapperMock.Object);

            var response = await handler.HandleAsync(command);

            _customerRepositoryMock.Verify(e => e.FindAsync(customerId), Times.Once());
            _customerRepositoryMock.Verify(e => e.UpdateAsync(updatedCustomer), Times.Once());
            _mapperMock.Verify(e => e.Map<Customer, EditCustomerCommandResponse>(customer), Times.Once());

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
