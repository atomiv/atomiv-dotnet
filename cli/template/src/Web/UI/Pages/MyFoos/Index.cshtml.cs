using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Optivem.Framework.Web.AspNetCore.RazorPages;
using Optivem.Cli.Web.UI.Models;
using Optivem.Cli.Web.UI.Services.Interfaces;

namespace Optivem.Cli.Web.UI.Pages.MyFoos
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