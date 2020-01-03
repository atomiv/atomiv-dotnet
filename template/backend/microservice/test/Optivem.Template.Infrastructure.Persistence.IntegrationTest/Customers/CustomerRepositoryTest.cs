using FluentAssertions;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xbehave;
using Xunit;

namespace Optivem.Template.Infrastructure.Persistence.IntegrationTest.Customers
{
    public class CustomerRepositoryTest : BaseTest
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerFactory _customerFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerRepositoryTest(Fixture fixture) : base(fixture)
        {
            _customerRepository = Fixture.GetService<ICustomerRepository>();
            _customerFactory = Fixture.GetService<ICustomerFactory>();
            _unitOfWork = Fixture.GetService<IUnitOfWork>();
        }

        [Scenario]
        public void CanAddCustomer(Customer customer)
        {
            "Given a valid customer"
                .x(() => customer = _customerFactory.Create("John", "Smith"));

            "When I add the customer to the repository"
                .x(async () => await _customerRepository.AddAsync(customer));

            "Then that customer exists in the repository"
                .x(() => _customerRepository.ExistsAsync(customer.Id));

            "And the retrieved customer matches the added customer"
                .x(async () =>
                {
                    var retrievedCustomer = await _customerRepository.FindAsync(customer.Id);
                    retrievedCustomer.Should().BeEquivalentTo(customer);
                });
        }
    }
}
