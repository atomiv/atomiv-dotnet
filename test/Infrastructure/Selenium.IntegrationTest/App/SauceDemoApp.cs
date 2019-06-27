using Optivem.Framework.Infrastructure.Selenium.IntegrationTest.Screens;

namespace Optivem.Framework.Infrastructure.Selenium.IntegrationTest.App
{
    public class SauceDemoApp : PageObject
    {
        public SauceDemoApp(Driver driver) 
            : base(driver)
        {
        }

        public SauceDemoLoginPage OpenLoginScreen()
        {
            return SauceDemoLoginPage.Open(Driver);
        }

        public SauceDemoLoginPage LoginScreen => new SauceDemoLoginPage(Driver);

        public SauceDemoInventoryPage InventoryScreen => new SauceDemoInventoryPage(Driver);
    }
}
