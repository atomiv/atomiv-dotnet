using Generator.Web.UI.Models;
using Generator.Web.UI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Generator.Web.UI.Services.Fake
{
    public class FakeCustomerPageService : ICustomerPageService
    {
        public Task CreateCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Customer>> ListCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    FirstName = "me",
                    LastName = "you"
                },

                new Customer
                {
                    FirstName = "me2",
                    LastName = "you2"
                },
            };

            return Task.FromResult((IList<Customer>) customers);
        }
    }
}
