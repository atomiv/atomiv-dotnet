using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures
{
    public class SauceDemoApp : App<SauceDemoLoginPage>
    {
        public SauceDemoApp(Driver driver)
            : base(driver)
        {
        }

        public SauceDemoLoginPage NavigateToLoginScreen()
        {
            return new SauceDemoLoginPage(Driver, true);
        }

        public SauceDemoInventoryPage NavigateToInventoryScreen()
        {
            return new SauceDemoInventoryPage(Driver, true);
        }
    }
}
