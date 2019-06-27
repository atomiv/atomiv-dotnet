using FluentAssertions;
using Optivem.Framework.Core.Common.WebAutomation;
using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Framework.Test.Common.WebAutomation;
using Optivem.Framework.Test.Selenium;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Pages
{
    public class SauceDemoLoginPage : PageObject
    {
        private const string Url = "https://www.saucedemo.com/";

        public SauceDemoLoginPage(Driver driver) : base(driver)
        {
            Driver.Url.Should().Be(Url);
        }

        private TextBox UserNameTextBox => Driver.FindTextBox(FindType.Id, "user-name");

        private TextBox PasswordTextBox => Driver.FindTextBox(FindType.Id, "password");

        private Button LoginButton => Driver.FindButton(FindType.ClassName, "btn_action");

        private Element ErrorElement => Driver.FindElement(FindType.XPath, "//h3[@data-test='error']");

        public SauceDemoInventoryPage LoginAs(string userName, string password)
        {
            UserNameTextBox.EnterText(userName);
            PasswordTextBox.EnterText(password);
            LoginButton.Click();

            return new SauceDemoInventoryPage(Driver);
        }

        public SauceDemoLoginPage LoginAsExpectingError(string userName, string password)
        {
            UserNameTextBox.EnterText(userName);
            PasswordTextBox.EnterText(password);
            LoginButton.Click();

            return new SauceDemoLoginPage(Driver);
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

        public static SauceDemoLoginPage Open(Driver driver)
        {
            driver.Url = Url;
            return new SauceDemoLoginPage(driver);
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
