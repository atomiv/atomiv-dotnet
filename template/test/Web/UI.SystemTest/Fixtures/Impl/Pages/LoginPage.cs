using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages.Interfaces;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Pages
{
    public class LoginPage : Page, ILoginPage
    {
        public LoginPage(Driver finder, bool navigateTo = false) 
            : base(finder, PageUrl, navigateTo)
        {
        }

        public static string PageUrl = "https://www.saucedemo.com/";

        public static bool IsOpen(Driver finder)
        {
            return finder.Url == PageUrl;
        }

        private TextBox UserNameTextBox => Finder.FindTextBox(FindBy.Id("user-name"));

        private TextBox PasswordTextBox => Finder.FindTextBox(FindBy.Id("password"));

        private Button LoginButton => Finder.FindButton(FindBy.CssSelector(".btn_action"));

        private ErrorElement ErrorElement => Finder.FindElement(FindBy.CssSelector("*[data-test='error']"), e => new ErrorElement(e));

        public void ClickLogin()
        {
            LoginButton.Click();
        }

        public void InputUserName(string userName)
        {
            UserNameTextBox.EnterText(userName);
        }

        public void InputPassword(string password)
        {
            PasswordTextBox.EnterText(password);
        }

        public IProductPage LoginAs(string userName, string password)
        {
            InputUserName(userName);
            InputPassword(password);
            ClickLogin();

            return new ProductPage(Finder, false);
        }

        public string LoginAsExpectingErrorMessage(string userName, string password)
        {
            UserNameTextBox.EnterText(userName);
            PasswordTextBox.EnterText(password);
            LoginButton.Click();

            return ErrorElement.Text;
        }

        public bool HasErrorMessage()
        {
            return ErrorElement != null;
        }

        public string GetErrorMessage()
        {
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
