using Optivem.Template.Core.Domain.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Template.Infrastructure.Persistence.IntegrationTest
{
    public class Test : IClassFixture<Fixture>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerFactory _customerFactory;

        public Test(Fixture fixture)
        {
            Fixture = fixture;

            _customerRepository = Fixture.GetService<ICustomerRepository>();
            _customerFactory = Fixture.GetService<ICustomerFactory>();
        }

        public Fixture Fixture { get; }

        protected async Task<List<Customer>> CreateSomeCustomersAsync()
        {
            var customers = new List<Customer>();

            for (var i = 0; i < 10; i++)
            {
                var customer = _customerFactory.Create($"John{i}", $"Smith{i}");
                await _customerRepository.AddAsync(customer);
                customers.Add(customer);
            }

            return customers;
        }
    }
}
