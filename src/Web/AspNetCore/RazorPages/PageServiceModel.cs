using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Optivem.Framework.Web.AspNetCore.RazorPages
{
    public class PageServiceModel<T> : PageModel where T : IPageService
    {
        public PageServiceModel(T service)
        {
            Service = service;
        }

        public T Service { get; }
    }
}
