using Optivem.Framework.Infrastructure.Selenium.IntegrationTest.Screens;
using Optivem.Framework.Test.Common.WebAutomation;

namespace Optivem.Framework.Infrastructure.Selenium.IntegrationTest.App
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
