using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures
{
    public class SauceDemoApp : App<SauceDemoLoginPage>
    {
        public SauceDemoApp(Driver finder)
            : base(finder)
        {
        }

        public SauceDemoLoginPage NavigateToLoginScreen()
        {
            return new SauceDemoLoginPage(Finder, true);
        }

        public SauceDemoInventoryPage NavigateToInventoryScreen()
        {
            return new SauceDemoInventoryPage(Finder, true);
        }
    }
}
