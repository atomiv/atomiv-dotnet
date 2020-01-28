using FluentAssertions;
using Optivem.Atomiv.Template.Core.Domain.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Atomiv.Template.Infrastructure.Persistence.IntegrationTest.Customers
{
    public class CustomerRepositoryTest : BaseTest
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerFactory _customerFactory;

        public CustomerRepositoryTest(Fixture fixture) : base(fixture)
        {
            _customerRepository = Fixture.GetService<ICustomerRepository>();
            _customerFactory = Fixture.GetService<ICustomerFactory>();
        }

        [Fact]
        public async Task CanAddNewCustomer()
        {
            // Arrange

            await CreateSomeCustomersAsync();
            var customer = _customerFactory.Create("John", "Smith");

            // Act

            await _customerRepository.AddAsync(customer);

            // Assert

            var retrievedCustomer = await _customerRepository.FindAsync(customer.Id);
            retrievedCustomer.Should().BeEquivalentTo(customer);
        }

        [Fact]
        public async Task CanUpdateExistingCustomer()
        {
            // Arrange

            var customers = await CreateSomeCustomersAsync();

            var customer = customers[2];

            // Act

            customer.FirstName = "John_A";
            customer.LastName = "John_B";

            await _customerRepository.UpdateAsync(customer);

            // Assert

            var retrievedCustomer = await _customerRepository.FindAsync(customer.Id);
            retrievedCustomer.Should().BeEquivalentTo(customer);
        }

        [Fact]
        public async Task CanRemoveExistingCustomer()
        {
            // Arrange

            var customers = await CreateSomeCustomersAsync();

            var customer = customers[2];

            // Act

            await _customerRepository.RemoveAsync(customer.Id);

            // Assert

            var retrievedCustomer = await _customerRepository.FindAsync(customer.Id);
            retrievedCustomer.Should().BeNull();
        }
    }
}
