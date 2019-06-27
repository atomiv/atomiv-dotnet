using FluentAssertions;
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
            var loginPage = Fixture.App.NavigateToLoginScreen();
            var inventoryPage = loginPage.LoginAs("standard_user", "secret_sauce");

            inventoryPage.ProductSort.SelectByText("Name (Z to A)");
        }

        [Fact]
        public void Login_InvalidCredentialsMissingUserName_ShowsError()
        {
            var loginPage = Fixture.App.NavigateToLoginScreen();
            loginPage.LoginAsExpectingError("", "secret_sauce");

            var message = loginPage.GetErrorMessage();

            message.Should().Be("Epic sadface: Username is required");

        }
    }
}
