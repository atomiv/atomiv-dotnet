using Optivem.Framework.Infrastructure.Selenium.IntegrationTest.Screens;

namespace Optivem.Framework.Infrastructure.Selenium.IntegrationTest.App
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
