using Optivem.Infrastructure.Selenium.IntegrationTest.Screens;
using Optivem.Test.Common.WebAutomation;

namespace Optivem.Infrastructure.Selenium.IntegrationTest.App
{
    public class SauceDemoApp : TestScreen
    {
        public SauceDemoApp(TestDriver driver) 
            : base(driver)
        {
        }

        public SauceDemoLoginScreen OpenLoginScreen()
        {
            return SauceDemoLoginScreen.Open(Driver);
        }

        public SauceDemoLoginScreen LoginScreen => new SauceDemoLoginScreen(Driver);

        public SauceDemoInventoryScreen InventoryScreen => new SauceDemoInventoryScreen(Driver);
    }
}
