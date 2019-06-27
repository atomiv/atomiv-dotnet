using Optivem.Framework.Infrastructure.Selenium.IntegrationTest.Fixtures;
using Xunit;

namespace Optivem.Framework.Infrastructure.Selenium.IntegrationTest
{
    public class SauceDemoLoginTest : SauceDemoTest
    {
        public SauceDemoLoginTest(SauceDemoFixture fixture) : base(fixture)
        {
        }

        [Fact(Skip = "In progress")]
        public void TestValidLogin()
        {
            var loginScreen = Fixture.App.OpenLoginScreen();
            loginScreen.UserName.EnterText("standard_user");
            loginScreen.Password.EnterText("secret_sauce");

            // TODO: VC: Continue

            /*
            loginScreen.Login.Click();

            var inventoryScreen = app.InventoryScreen;

            inventoryScreen.ProductSort.SelectByText("Name (Z to A)");
            */
        }
    }
}