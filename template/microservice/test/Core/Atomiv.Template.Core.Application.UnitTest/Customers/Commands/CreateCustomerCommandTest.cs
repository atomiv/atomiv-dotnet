using FluentAssertions;
using Moq;
using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Commands.Customers;
using Atomiv.Template.Core.Application.Commands.Handlers.Customers;
using Atomiv.Template.Core.Application.Context;
using Atomiv.Template.Core.Domain.Customers;
using System.Threading.Tasks;
using Xunit;
using System;

namespace Atomiv.Template.Core.Application.UnitTest.Customers.Commands
{
    public class CreateCustomerCommandTest
    {
        [Fact]
        public async Task HandleAsync_Valid()
        {
            var applicationUserContextMock = new Mock<IApplicationUserContext>();
            var customerFactoryMock = new Mock<ICustomerFactory>();
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var mapperMock = new Mock<IMapper>();

            var command = new CreateCustomerCommand
            {
                FirstName = "Mary",
                LastName = "Smith",
            };

            var id = "926a4480-61f5-416a-a16f-5c722d8463f7";
            var referenceNumber = new CustomerReferenceNumber(DateTime.Now, "ABC12");
            var customer = new Customer(new CustomerIdentity(id), referenceNumber, "Mary", "Smith"); ;

            var expectedResponse = new CreateCustomerCommandResponse
            {
                Id = id,
                FirstName = "Mary",
                LastName = "Smith",
            };

            customerFactoryMock
                .Setup(e => e.CreateCustomer("Mary", "Smith"))
                .Returns(customer);

            customerRepositoryMock
                .Setup(e => e.AddAsync(customer));

            mapperMock
                .Setup(e => e.Map<Customer, CreateCustomerCommandResponse>(customer))
                .Returns(expectedResponse);

            var handler = new CreateCustomerCommandHandler(applicationUserContextMock.Object,
                customerFactoryMock.Object,
                customerRepositoryMock.Object,
                mapperMock.Object);

            var response = await handler.HandleAsync(command);

            customerFactoryMock.Verify(e => e.CreateCustomer("Mary", "Smith"), Times.Once());
            customerRepositoryMock.Verify(e => e.AddAsync(customer), Times.Once());
            mapperMock.Verify(e => e.Map<Customer, CreateCustomerCommandResponse>(customer), Times.Once());

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
