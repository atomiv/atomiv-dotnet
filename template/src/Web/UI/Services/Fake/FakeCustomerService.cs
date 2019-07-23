using Optivem.Template.Web.UI.Models;
using Optivem.Template.Web.UI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Template.Web.UI.Services.Fake
{
    public class FakeCustomerService : ICustomerService
    {
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
