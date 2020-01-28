using Microsoft.AspNetCore.Mvc;
using Optivem.Atomiv.Web.AspNetCore.RazorPages;
using Optivem.Cli.Web.UI.Models;
using Optivem.Cli.Web.UI.Services.Interfaces;
using System.Threading.Tasks;

namespace Optivem.Cli.Web.UI.Pages.MyFoos
{
    public class CreateModel : PageServiceModel<IMyFooPageService>
    {
        public CreateModel(IMyFooPageService service) : base(service)
        {
        }

        [BindProperty]
        public MyFoo MyFoo { get; set; }

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

            await Service.CreateMyFoo(MyFoo);

            return RedirectToPage("./Index");
        }
    }
}