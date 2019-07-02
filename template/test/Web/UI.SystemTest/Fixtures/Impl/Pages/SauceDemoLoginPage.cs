using FluentAssertions;
using Optivem.Framework.Core.Common.WebAutomation;
using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages.Interfaces;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Pages
{
    public class SauceDemoLoginPage : Page, ILoginPage
    {
        public SauceDemoLoginPage(Driver finder, bool navigateTo = false) 
            : base(finder, "https://www.saucedemo.com/", navigateTo)
        {
        }

        private TextBox UserNameTextBox => Finder.FindTextBox(FindBy.Id("user-name"));

        private TextBox PasswordTextBox => Finder.FindTextBox(FindBy.Id("password"));

        private Button LoginButton => Finder.FindButton(FindBy.CssSelector(".btn_action"));

        private ErrorElement ErrorElement => Finder.FindElement(FindBy.CssSelector("*[data-test='error']"), e => new ErrorElement(e));

        public IProductPage LoginAs(string userName, string password)
        {
            UserNameTextBox.EnterText(userName);
            PasswordTextBox.EnterText(password);
            LoginButton.Click();

            return new SauceDemoProductPage(Finder, false);
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
