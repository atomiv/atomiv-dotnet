using Optivem.Framework.Infrastructure.Selenium.IntegrationTest.Screens;
using Optivem.Framework.Test.Selenium;

namespace Optivem.Framework.Infrastructure.Selenium.IntegrationTest.App
{
    public class SauceDemoApp : TestPageObject
    {
        public SauceDemoApp(TestDriver driver) 
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
