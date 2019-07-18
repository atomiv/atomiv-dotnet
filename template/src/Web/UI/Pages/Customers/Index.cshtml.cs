using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Optivem.Template.UI.Models;

namespace Optivem.Template.UI.Pages.Customers
{
    public class IndexModel : PageModel
    {
        public IList<Customer> Customers { get; set; }

        public void OnGet()
        {
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
        }
    }
}