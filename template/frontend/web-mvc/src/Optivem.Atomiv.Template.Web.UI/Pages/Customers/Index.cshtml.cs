using Optivem.Atomiv.Web.AspNetCore.RazorPages;
using Optivem.Atomiv.Template.Web.UI.Models;
using Optivem.Atomiv.Template.Web.UI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Web.UI.Pages.Customers
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}