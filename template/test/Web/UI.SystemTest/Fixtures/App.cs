using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Interfaces;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages.Interfaces;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures
{
    public class App : App<SauceDemoLoginPage>, IApp
    {
        public App(Driver finder)
            : base(finder)
        {
        }

        public ILoginPage OpenLoginPage()
        {
            return new SauceDemoLoginPage(Finder, true);
        }

        public IProductPage OpenProductPage()
        {
            return new SauceDemoProductPage(Finder, true);
        }
    }
}
