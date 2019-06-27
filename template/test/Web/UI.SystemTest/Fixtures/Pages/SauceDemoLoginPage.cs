using FluentAssertions;
using Optivem.Framework.Core.Common.WebAutomation;
using Optivem.Framework.Test.Selenium;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Pages
{
    public class SauceDemoLoginPage : TestPageObject
    {
        private const string Url = "https://www.saucedemo.com/";

        public SauceDemoLoginPage(TestDriver driver) : base(driver)
        {
            Driver.Url.Should().Be(Url);
        }

        private TestTextBox UserNameTextBox => Driver.FindTextBoxById("user-name");

        private TestTextBox PasswordTextBox => Driver.FindTextBoxById("password");

        private TestButton LoginButton => Driver.FindButtonByClass("btn_action");

        private TestElement ErrorElement => Driver.FindElement(FindType.XPath, "//h3[@data-test='error']");

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

            return errorElement.Element.WebElement.Text;
        }

        public static SauceDemoLoginPage Open(TestDriver driver)
        {
            driver.Url = Url;
            return new SauceDemoLoginPage(driver);
        }


    }

    public class LoginErrorRegion : TestPageObject
    {
        public LoginErrorRegion(TestDriver driver) : base(driver)
        {

        }

        public string Text { get; }
    }
}
