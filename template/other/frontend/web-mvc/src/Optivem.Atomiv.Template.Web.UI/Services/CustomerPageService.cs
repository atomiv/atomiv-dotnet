using Optivem.Atomiv.Web.AspNetCore.RazorPages;
using Optivem.Atomiv.Template.Core.Application.Customers;
using Optivem.Atomiv.Template.Core.Application.Customers.Requests;
using Optivem.Atomiv.Template.Core.Application.Customers.Responses;
using Optivem.Atomiv.Template.Web.UI.Models;
using Optivem.Atomiv.Template.Web.UI.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Web.UI.Services
{
    public class CustomerPageService : PageService<ICustomerService>, ICustomerPageService
    {
        public CustomerPageService(ICustomerService service)
            : base(service)
        {
        }

        public async Task CreateCustomer(Customer customer)
        {
            var request = new CreateCustomerRequest
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
            };

            await Service.CreateCustomerAsync(request);
        }

        public async Task<IList<Customer>> ListCustomers()
        {
            var request = new ListCustomersRequest();
            var response = await Service.ListCustomersAsync(request);

            return response.Records.Select(Get).ToList();
        }

        private Customer Get(ListCustomersRecordResponse record)
        {
            return new Customer
            {
                Id = record.Id,
                FirstName = record.Name, // TODO: VC: Use browse
            };
        }
    }
}