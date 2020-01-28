using Optivem.Atomiv.Infrastructure.Selenium;
using Optivem.Generator.Web.UI.Client.Interface;
using Optivem.Generator.Web.UI.Client.Interface.Pages;
using Optivem.Generator.Web.UI.Client.Pages;

namespace Optivem.Generator.Web.UI.Client
{
    public class App : App<CreateCustomerPage>, IApp
    {
        public App(Driver finder, string url) : base(finder)
        {
            Url = url;
        }

        public string Url { get; }

        public ICreateCustomerPage NavigateToCreateCustomerPage()
        {
            return new CreateCustomerPage(Url, Finder, true);
        }
    }
}
