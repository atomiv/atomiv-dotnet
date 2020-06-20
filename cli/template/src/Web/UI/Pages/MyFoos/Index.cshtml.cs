using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Atomiv.Web.AspNetCore.RazorPages;
using Cli.Web.UI.Models;
using Cli.Web.UI.Services.Interfaces;

namespace Cli.Web.UI.Pages.MyFoos
{
    public class IndexModel : PageServiceModel<IMyFooPageService>
    {
        public IndexModel(IMyFooPageService service) : base(service)
        {
        }

        public IList<MyFoo> MyFoos { get; set; }

        public async Task OnGet()
        {
            try
            {
                MyFoos = await Service.ListMyFoos();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}