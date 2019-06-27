using Optivem.Framework.Test.Selenium;
using Optivem.Framework.Test.Xunit;
using Optivem.Template.Web.UI.SystemTest.Fixtures;
using Xunit;

namespace Optivem.Template.Web.UI.SystemTest
{
    public class SauceDemoLoginTest : SauceDemoTest
    {
        public SauceDemoLoginTest(SauceDemoFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void Login_ValidCredentials_OpensInventoryScreen()
        {
            var loginScreen = Fixture.App.NavigateToLoginScreen();
            var inventoryScreen = loginScreen.LoginAs("standard_user", "secret_sauce");

            inventoryScreen.ProductSort.SelectByText("Name (Z to A)");
        }

        [Fact]
        public void Login_InvalidCredentialsMissingUserName_ShowsError()
        {
            var loginScreen = Fixture.App.NavigateToLoginScreen();
            loginScreen.LoginAsExpectingError("", "secret_sauce");


        }
    }
}
