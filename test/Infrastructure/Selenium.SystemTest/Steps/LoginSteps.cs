using FluentAssertions;
using Optivem.Atomiv.Infrastructure.Selenium.SystemTest.Fixtures;
using Optivem.Atomiv.Infrastructure.Selenium.SystemTest.Fixtures.Pages.Interfaces;
using TechTalk.SpecFlow;

namespace Optivem.Atomiv.Infrastructure.Selenium.SystemTest
{
    [Binding]
    public class LoginSteps : AppTest
    {
        private ILoginPage _loginPage;

        public LoginSteps(AppFixture fixture) : base(fixture)
        {
        }

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _loginPage = Fixture.App.OpenLoginPage();
        }

        [Given(@"I have entered the username '(.*)'")]
        public void GivenIHaveEnteredTheUsername(string userName)
        {
            _loginPage.InputUserName(userName);
        }

        [Given(@"I have entered the password '(.*)'")]
        public void GivenIHaveEnteredThePassword(string password)
        {
            _loginPage.InputPassword(password);
        }

        [When(@"I press login")]
        public void WhenIPressLogin()
        {
            _loginPage.ClickLogin();
        }

        [Then(@"I see the products page")]
        public void ThenISeeTheProductsPage()
        {
            Fixture.App.IsProductPageOpen().Should().BeTrue();
        }

        [Then(@"I see the error message '(.*)'")]
        public void ThenISeeTheErrorMessage(string errorMessage)
        {
            Fixture.App.IsLoginPageOpen().Should().BeTrue();
            _loginPage.HasErrorMessage().Should().BeTrue();
            _loginPage.GetErrorMessage().Should().Be(errorMessage);
        }
    }
}