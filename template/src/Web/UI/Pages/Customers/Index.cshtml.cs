using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Optivem.Framework.Web.AspNetCore.RazorPages;
using Optivem.Template.UI.Models;
using Optivem.Template.UI.Services;
using Optivem.Template.UI.Services.Interfaces;

namespace Optivem.Template.UI.Pages.Customers
{
    public class IndexModel : ServicePageModel<ICustomerService>
    {
        public IndexModel(ICustomerService service) : base(service)
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