using Optivem.Framework.Test.Selenium;
using Optivem.Framework.Test.Xunit;
using Optivem.Template.Web.UI.SystemTest.Fixtures;
using Xunit;

namespace Optivem.Template.Web.UI.SystemTest
{
    public class SauceDemoLoginTest : FixtureTest<ChromeDriverFixture>
    {
        public SauceDemoLoginTest(ChromeDriverFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void TestValidLogin()
        {
            var driver = Fixture.TestDriver;
            var app = new SauceDemoApp(driver);

            var loginScreen = app.OpenLoginScreen();
            loginScreen.UserNameTextBox.EnterText("standard_user");
            loginScreen.PasswordTextBox.EnterText("secret_sauce");

            loginScreen.LoginButton.Click();

            var inventoryScreen = app.InventoryScreen;

            inventoryScreen.ProductSort.SelectByText("Name (Z to A)");
        }
    }
}
