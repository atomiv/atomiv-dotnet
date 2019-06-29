using FluentAssertions;
using Optivem.Framework.Core.Common.WebAutomation;
using Optivem.Framework.Infrastructure.Selenium;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Pages
{
    public class SauceDemoLoginPage : Page
    {
        public SauceDemoLoginPage(Driver finder, bool navigateTo = false) 
            : base(finder, "https://www.saucedemo.com/", navigateTo)
        {
        }

        private TextBox UserNameTextBox => Finder.FindTextBox(FindBy.Id("user-name"));

        private TextBox PasswordTextBox => Finder.FindTextBox(FindBy.Id("password"));

        private Button LoginButton => Finder.FindButton(FindBy.CssSelector(".btn_action"));

        private ErrorElement ErrorElement => Finder.FindElement(FindBy.CssSelector("*[data-test='error']"), e => new ErrorElement(e));

        public SauceDemoInventoryPage LoginAs(string userName, string password)
        {
            UserNameTextBox.EnterText(userName);
            PasswordTextBox.EnterText(password);
            LoginButton.Click();

            return new SauceDemoInventoryPage(Finder, false);
        }

        public string LoginAsExpectingErrorMessage(string userName, string password)
        {
            UserNameTextBox.EnterText(userName);
            PasswordTextBox.EnterText(password);
            LoginButton.Click();

            return ErrorElement.Text;
        }
    }

    public class ErrorElement : CompositeElement
    {
        public ErrorElement(ElementRoot finder) : base(finder)
        {
        }

        public string Text => Finder.Text;
    }
}
