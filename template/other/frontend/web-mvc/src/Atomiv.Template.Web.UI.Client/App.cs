using Atomiv.Infrastructure.Selenium;
using Atomiv.Template.Web.UI.Client.Interface;
using Atomiv.Template.Web.UI.Client.Interface.Pages;
using Atomiv.Template.Web.UI.Client.Pages;

namespace Atomiv.Template.Web.UI.Client
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