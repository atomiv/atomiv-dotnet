namespace Optivem.Template.Web.UI.Services
{
    // TODO: VC: Consider moving into framework

    // TODO: VC: Consider base for the api since one view will most likely get data from multiple apis

    public class BaseViewService<TService>
    {
        public BaseViewService(TService service)
        {
            Service = service;
        }

        public TService Service { get; }
    }
}
