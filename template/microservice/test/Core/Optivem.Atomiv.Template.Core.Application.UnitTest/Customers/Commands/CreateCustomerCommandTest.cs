using FluentAssertions;
using Moq;
using Optivem.Atomiv.Core.Application;
using Optivem.Atomiv.Template.Core.Application.Commands.Customers;
using Optivem.Atomiv.Template.Core.Application.Customers.Commands;
using Optivem.Atomiv.Template.Core.Domain.Customers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Atomiv.Template.Core.Application.UnitTest.Customers.Commands
{
    public class CreateCustomerCommandTest
    {
        [Fact]
        public async Task HandleAsync_Valid()
        {
            var customerFactoryMock = new Mock<ICustomerFactory>();
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mapperMock = new Mock<IMapper>();

            var command = new CreateCustomerCommand
            {
                FirstName = "Mary",
                LastName = "Smith",
            };

            var id = Guid.Parse("926a4480-61f5-416a-a16f-5c722d8463f7");
            var customer = new Customer(new CustomerIdentity(id), "Mary", "Smith"); ;

            var expectedResponse = new CreateCustomerCommandResponse
            {
                Id = id,
                FirstName = "Mary",
                LastName = "Smith",
            };

            customerFactoryMock
                .Setup(e => e.Create("Mary", "Smith"))
                .Returns(customer);

            customerRepositoryMock
                .Setup(e => e.AddAsync(customer));

            mapperMock
                .Setup(e => e.Map<Customer, CreateCustomerCommandResponse>(customer))
                .Returns(expectedResponse);

            var handler = new CreateCustomerCommandHandler(customerFactoryMock.Object,
                customerRepositoryMock.Object,
                mapperMock.Object);

            var response = await handler.HandleAsync(command);

            customerFactoryMock.Verify(e => e.Create("Mary", "Smith"), Times.Once());
            customerRepositoryMock.Verify(e => e.AddAsync(customer), Times.Once());
            mapperMock.Verify(e => e.Map<Customer, CreateCustomerCommandResponse>(customer), Times.Once());

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
