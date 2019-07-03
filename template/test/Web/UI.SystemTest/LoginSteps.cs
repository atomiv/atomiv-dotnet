using Optivem.Template.Web.UI.SystemTest.Fixtures;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages.Interfaces;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace Optivem.Template.Web.UI.SystemTest
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
        
        [Given(@"I have entered username '(.*)' and password '(.*)'")]
        public void GivenIHaveEnteredUsernameAndPassword(string userName, string password)
        {
            _loginPage.InputUserName(userName);
            _loginPage.InputPassword(password);
        }
        
        [When(@"I press login")]
        public void WhenIPressLogin()
        {
            _loginPage.ClickLogin();
        }
        
        [Then(@"I see the inventory page")]
        public void ThenISeeTheInventoryPage()
        {
            Assert.True(Fixture.App.IsProductPageOpen());
        }
    }
}
