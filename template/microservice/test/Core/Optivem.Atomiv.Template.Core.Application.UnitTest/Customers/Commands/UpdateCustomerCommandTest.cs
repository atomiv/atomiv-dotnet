using FluentAssertions;
using Moq;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Customers.Commands;
using Optivem.Atomiv.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Atomiv.Template.Core.Application.UnitTest.Customers.Commands
{
    public class UpdateCustomerCommandTest
    {
        [Fact]
        public async Task HandleAsync_Valid()
        {
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mapperMock = new Mock<IMapper>();

            var id = Guid.Parse("926a4480-61f5-416a-a16f-5c722d8463f7");

            var command = new UpdateCustomerCommand
            {
                Id = id,
                FirstName = "Mary 2",
                LastName = "Smith 2",
            };

            var customerId = new CustomerIdentity(id);
            var customer = new Customer(customerId, "Mary", "Smith");

            var updatedCustomer = new Customer(customerId, "Mary 2", "Smith 2");

            var expectedResponse = new UpdateCustomerCommandResponse
            {
                Id = id,
                FirstName = "Mary 2",
                LastName = "Smith 2",
            };

            customerRepositoryMock
                .Setup(e => e.FindAsync(customerId))
                .ReturnsAsync(customer);

            customerRepositoryMock
                .Setup(e => e.UpdateAsync(updatedCustomer));

            mapperMock
                .Setup(e => e.Map<Customer, UpdateCustomerCommandResponse>(updatedCustomer))
                .Returns(expectedResponse);

            var handler = new UpdateCustomerCommandHandler(customerRepositoryMock.Object,
                mapperMock.Object);

            var response = await handler.HandleAsync(command);

            customerRepositoryMock.Verify(e => e.FindAsync(customerId), Times.Once());
            customerRepositoryMock.Verify(e => e.UpdateAsync(updatedCustomer), Times.Once());
            mapperMock.Verify(e => e.Map<Customer, UpdateCustomerCommandResponse>(customer), Times.Once());

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
