using FluentAssertions;
using Optivem.Template.Core.Domain.Customers;
using System.Collections.Generic;
using Xbehave;

namespace Optivem.Template.Infrastructure.Persistence.IntegrationTest.Customers
{
    public class CustomerRepositoryTest : Test
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerFactory _customerFactory;

        private List<Customer> _customers;

        public CustomerRepositoryTest(Fixture fixture) : base(fixture)
        {
            _customerRepository = Fixture.GetService<ICustomerRepository>();
            _customerFactory = Fixture.GetService<ICustomerFactory>();
        }

        [Background]
        public void Background()
        {
            "Given that there are some customers in the repository"
                .x(async () =>
                {
                    _customers = new List<Customer>();

                    for (var i = 0; i < 10; i++)
                    {
                        var customer = _customerFactory.Create($"John{i}", $"Smith{i}");
                        await _customerRepository.AddAsync(customer);
                        _customers.Add(customer);
                    }
                });
        }


        [Scenario]
        public void CanAddNewCustomer(Customer customer)
        {
            "Given a valid customer"
                .x(() => customer = _customerFactory.Create("John", "Smith"));

            "When I add the customer to the repository"
                .x(async () => await _customerRepository.AddAsync(customer));

            "Then the retrieved customer matches the added customer"
                .x(async () =>
                {
                    var retrievedCustomer = await _customerRepository.FindAsync(customer.Id);
                    retrievedCustomer.Should().BeEquivalentTo(customer);
                });
        }

        [Scenario]
        public void CanUpdateExistingCustomer(Customer customer)
        {
            "Given some existing customer"
                .x(() => customer = _customers[2]);

            "When I make changes to that customer"
                .x((() =>
                {
                    customer.FirstName = "John_A";
                    customer.LastName = "John_B";
                }));

            "And I update that customer in the repository"
                .x(async () => await _customerRepository.UpdateAsync(customer));

            "Then I can retrieve the updated customer from the repository"
                .x(async () =>
                {
                    var retrievedCustomer = await _customerRepository.FindAsync(customer.Id);
                    retrievedCustomer.Should().BeEquivalentTo(customer);
                });
        }

        [Scenario]
        public void CanRemoveExistingCustomer(Customer customer)
        {
            "Given some existing customer"
                .x(() => customer = _customers[2]);

            "When I remove that customer from the repository"
                .x(async () => await _customerRepository.RemoveAsync(customer.Id));

            "Then it has been removed"
                .x(async () =>
                {
                    var retrievedCustomer = await _customerRepository.FindAsync(customer.Id);
                    retrievedCustomer.Should().BeNull();
                });
        }
    }
}
