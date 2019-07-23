using System.Collections.Generic;
using Optivem.Framework.Web.AspNetCore.RazorPages;
using Optivem.Template.Web.UI.Models;
using Optivem.Template.Web.UI.Services.Interfaces;

namespace Optivem.Template.Web.UI.Pages.Customers
{
    public class IndexModel : ServicePageModel<ICustomerViewService>
    {
        public IndexModel(ICustomerViewService service) : base(service)
        {
        }

        public IList<Customer> Customers { get; set; }

        public void OnGet()
        {
            /*

            Customers = new List<Customer>
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

            */

            Customers = Service.ListCustomers().GetAwaiter().GetResult();
        }
    }
}