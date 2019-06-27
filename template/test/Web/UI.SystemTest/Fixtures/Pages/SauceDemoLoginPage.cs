using FluentAssertions;
using Optivem.Framework.Core.Common.WebAutomation;
using Optivem.Framework.Infrastructure.Selenium;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Pages
{
    public class SauceDemoLoginPage : Page
    {
        public SauceDemoLoginPage(Driver driver, bool navigateTo) 
            : base(driver, "https://www.saucedemo.com/", navigateTo)
        {
            Driver.Url.Should().Be(Url);
        }

        private TextBox UserNameTextBox => Driver.FindTextBox(FindType.Id, "user-name");

        private TextBox PasswordTextBox => Driver.FindTextBox(FindType.Id, "password");

        private Button LoginButton => Driver.FindButton(FindType.ClassName, "btn_action");

        private Element ErrorElement => Driver.FindElement(FindType.CssSelector, "h3[data-test='error']");

        public SauceDemoInventoryPage LoginAs(string userName, string password)
        {
            UserNameTextBox.EnterText(userName);
            PasswordTextBox.EnterText(password);
            LoginButton.Click();

            return new SauceDemoInventoryPage(Driver, true);
        }

        public SauceDemoLoginPage LoginAsExpectingError(string userName, string password)
        {
            UserNameTextBox.EnterText(userName);
            PasswordTextBox.EnterText(password);
            LoginButton.Click();

            return new SauceDemoLoginPage(Driver, true);
        }

        public string GetErrorMessage()
        {
            var errorElement = ErrorElement;

            if(errorElement == null)
            {
                return null;
            }

            return errorElement.WebElement.Text;
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
