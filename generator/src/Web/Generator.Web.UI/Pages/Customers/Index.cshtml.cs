using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atomiv.Web.AspNetCore.RazorPages;
using Generator.Web.UI.Models;
using Generator.Web.UI.Services.Interfaces;

namespace Generator.Web.UI.Pages.Customers
{
    public class IndexModel : PageServiceModel<ICustomerPageService>
    {
        public IndexModel(ICustomerPageService service) : base(service)
        {
        }

        public IList<Customer> Customers { get; set; }

        public async Task OnGet()
        {
            try
            {
                Customers = await Service.ListCustomers();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}