using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Optivem.Framework.Web.AspNetCore.RazorPages;
using Optivem.Template.Web.UI.Models;
using Optivem.Template.Web.UI.Services.Interfaces;
using System.Threading.Tasks;

namespace Optivem.Template.Web.UI.Pages.Customers
{
    public class CreateModel : PageServiceModel<ICustomerPageService>
    {
        public CreateModel(ICustomerPageService service) : base(service)
        {
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await Service.CreateCustomer(Customer);

            return RedirectToPage("./Index");
        }
    }
}