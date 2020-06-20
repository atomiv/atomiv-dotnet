using Atomiv.Web.AspNetCore.RazorPages;
using Cli.Web.UI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cli.Web.UI.Services.Interfaces
{
    public interface IMyFooPageService : IPageService
    {
        Task<IList<MyFoo>> ListMyFoos();

        Task CreateMyFoo(MyFoo myFoo);
    }
}
