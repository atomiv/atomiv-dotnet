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
        private readonly Mock<IApplicationUserContext> _applicationUserContextMock;
        private readonly Mock<ICustomerFactory> _customerFactoryMock;
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;

        public CreateCustomerCommandTest()
        {
            _applicationUserContextMock = new Mock<IApplicationUserContext>();
            _customerFactoryMock = new Mock<ICustomerFactory>();
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
        }

        [Fact]
        public async Task HandleAsync_Valid()
        {
            var command = new CreateCustomerCommand
            {
                FirstName = "Mary",
                LastName = "Smith",
            };

            var id = Guid.Parse("926a4480-61f5-416a-a16f-5c722d8463f7");
            var referenceNumber = new CustomerReferenceNumber(DateTime.Now, "ABC12");
            var customer = new Customer(new CustomerIdentity(id), referenceNumber, "Mary", "Smith"); ;

            var expectedResponse = new CreateCustomerCommandResponse
            {
                Id = id,
                FirstName = "Mary",
                LastName = "Smith",
            };

            _customerFactoryMock
                .Setup(e => e.CreateCustomer("Mary", "Smith"))
                .Returns(customer);

            _customerRepositoryMock
                .Setup(e => e.AddAsync(customer));

            _unitOfWorkMock
                .Setup(e => e.CommitAsync());

            _mapperMock
                .Setup(e => e.Map<Customer, CreateCustomerCommandResponse>(customer))
                .Returns(expectedResponse);

            var handler = new CreateCustomerCommandHandler(_applicationUserContextMock.Object,
                _customerFactoryMock.Object,
                _customerRepositoryMock.Object,
                _unitOfWorkMock.Object,
                _mapperMock.Object);

            var response = await handler.HandleAsync(command);

            _customerFactoryMock.Verify(e => e.CreateCustomer("Mary", "Smith"), Times.Once());
            _customerRepositoryMock.Verify(e => e.AddAsync(customer), Times.Once());
            _mapperMock.Verify(e => e.Map<Customer, CreateCustomerCommandResponse>(customer), Times.Once());

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
