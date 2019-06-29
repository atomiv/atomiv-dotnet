using FluentAssertions;
using Optivem.Framework.Core.Common.WebAutomation;
using Optivem.Framework.Infrastructure.Selenium;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Pages
{
    public class SauceDemoLoginPage : Page
    {
        public SauceDemoLoginPage(Driver driver, bool navigateTo = false) 
            : base(driver, "https://www.saucedemo.com/", navigateTo)
        {
            Driver.Url.Should().Be(Url);
        }

        private TextBox UserNameTextBox => Driver.FindTextBox(FindBy.Id("user-name"));

        private TextBox PasswordTextBox => Driver.FindTextBox(FindBy.Id("password"));

        private Button LoginButton => Driver.FindButton(FindBy.CssSelector(".btn_action"));

        private Element ErrorElement => Driver.FindElement(FindBy.CssSelector("*[data-test='error']"));

        public SauceDemoInventoryPage LoginAs(string userName, string password)
        {
            UserNameTextBox.EnterText(userName);
            PasswordTextBox.EnterText(password);
            LoginButton.Click();

            return new SauceDemoInventoryPage(Driver, false);
        }

        public string LoginAsExpectingErrorMessage(string userName, string password)
        {
            UserNameTextBox.EnterText(userName);
            PasswordTextBox.EnterText(password);
            LoginButton.Click();

            return ErrorElement.Text;
        }
    }

    public class LoginErrorRegion : PageObject
    {
        public LoginErrorRegion(Driver driver) : base(driver)
        {

        }

        public string Text { get; }
    }
}
