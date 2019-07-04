using FluentAssertions;
using Optivem.Template.Web.UI.SystemTest.Fixtures;
using Xunit;

namespace Optivem.Template.Web.UI.SystemTest
{
    public class LoginTest : AppTest
    {
        public LoginTest(AppFixture fixture) : base(fixture)
        {
        }


        /*
        [Fact]
        public void Login_ValidCredentials_OpensInventoryScreen()
        {
            var loginPage = Fixture.App.OpenLoginPage();
            var inventoryPage = loginPage.LoginAs("standard_user", "secret_sauce");
        }

        [Fact]
        public void Login_InvalidCredentialsMissingUserName_ShowsError()
        {
            var loginPage = Fixture.App.OpenLoginPage();
            var message = loginPage.LoginAsExpectingErrorMessage("", "secret_sauce");

            message.Should().Be("Epic sadface: Username is required");

        }

        */
    }
}
