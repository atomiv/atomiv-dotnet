using Atomiv.Infrastructure.Selenium.SystemTest.Fixtures.Pages.Interfaces;

namespace Atomiv.Infrastructure.Selenium.SystemTest.Fixtures.Pages
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
            UserNameTextBox.InputText(userName);
        }

        public void InputPassword(string password)
        {
            PasswordTextBox.InputText(password);
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