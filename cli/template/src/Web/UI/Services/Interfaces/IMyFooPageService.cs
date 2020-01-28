using Optivem.Atomiv.Web.AspNetCore.RazorPages;
using Optivem.Cli.Web.UI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Cli.Web.UI.Services.Interfaces
{
    public interface IMyFooPageService : IPageService
    {
        Task<IList<MyFoo>> ListMyFoos();

        Task CreateMyFoo(MyFoo myFoo);
    }
}
