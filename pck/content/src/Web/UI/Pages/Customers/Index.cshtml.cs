using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Optivem.Framework.Web.AspNetCore.RazorPages;
using Optivem.Template.Web.UI.Models;
using Optivem.Template.Web.UI.Services.Interfaces;

namespace Optivem.Template.Web.UI.Pages.Customers
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