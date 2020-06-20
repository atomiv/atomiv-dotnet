namespace Atomiv.Infrastructure.Selenium.SystemTest.Fixtures.Pages.Interfaces
{
    public interface ILoginPage
    {
        void InputUserName(string userName);

        void InputPassword(string password);

        void ClickLogin();

        bool HasErrorMessage();

        string GetErrorMessage();
    }
}