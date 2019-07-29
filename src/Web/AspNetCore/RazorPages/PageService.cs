namespace Optivem.Framework.Web.AspNetCore.RazorPages
{
    // TODO: VC: Consider base for the api since one view will most likely get data from multiple apis
    // example on orders view, dropdown for list of products

    public class PageService<TService> : IPageService
    {
        public PageService(TService service)
        {
            Service = service;
        }

        public TService Service { get; }
    }
}
