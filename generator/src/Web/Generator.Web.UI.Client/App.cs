using Atomiv.Infrastructure.Selenium;
using Generator.Web.UI.Client.Interface;
using Generator.Web.UI.Client.Interface.Pages;
using Generator.Web.UI.Client.Pages;

namespace Generator.Web.UI.Client
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
