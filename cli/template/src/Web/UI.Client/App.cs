using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Cli.Web.UI.Client.Interface;
using Optivem.Cli.Web.UI.Client.Interface.Pages;
using Optivem.Cli.Web.UI.Client.Pages;

namespace Optivem.Cli.Web.UI.Client
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
