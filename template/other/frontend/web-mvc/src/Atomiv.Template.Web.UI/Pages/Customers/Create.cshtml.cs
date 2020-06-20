using Microsoft.AspNetCore.Mvc;
using Atomiv.Web.AspNetCore.RazorPages;
using Atomiv.Template.Web.UI.Models;
using Atomiv.Template.Web.UI.Services.Interfaces;
using System.Threading.Tasks;

namespace Atomiv.Template.Web.UI.Pages.Customers
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