using Microsoft.AspNetCore.Mvc;
using Atomiv.Web.AspNetCore.RazorPages;
using Cli.Web.UI.Models;
using Cli.Web.UI.Services.Interfaces;
using System.Threading.Tasks;

namespace Cli.Web.UI.Pages.MyFoos
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