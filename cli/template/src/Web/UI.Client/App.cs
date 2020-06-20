using Atomiv.Infrastructure.Selenium;
using Cli.Web.UI.Client.Interface;
using Cli.Web.UI.Client.Interface.Pages;
using Cli.Web.UI.Client.Pages;

namespace Cli.Web.UI.Client
{
    public class App : App<CreateMyFooPage>, IApp
    {
        public App(Driver finder, string url) : base(finder)
        {
            Url = url;
        }

        public string Url { get; }

        public ICreateMyFooPage NavigateToCreateMyFooPage()
        {
            return new CreateMyFooPage(Url, Finder, true);
        }
    }
}
