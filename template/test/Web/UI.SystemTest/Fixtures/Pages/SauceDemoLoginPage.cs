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

        public TestTextBox UserNameTextBox => Driver.FindTextBoxById("user-name");

        public TestTextBox PasswordTextBox => Driver.FindTextBoxById("password");

        public TestButton LoginButton => Driver.FindButtonByClass("btn_action");

        public TestElement ErrorElement => Driver.FindElement(FindType.XPath, "//h3[@data-test='error']");

        public void LoginWith(string userName, string password)
        {
            UserNameTextBox.EnterText(userName);
            PasswordTextBox.EnterText(password);
            LoginButton.Click();
        }

        public bool IsLoggedIn()
        {
            return Driver.Url != Url;
        }

        public bool HasError()
        {
            return ErrorElement != null;
        }

        /*

        public string GetError()
        {
            return ErrorElement.Element.
        }

        */

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
