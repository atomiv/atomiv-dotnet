namespace Cli.Web.UI.Client.Interface.Pages
{
    public interface ICreateMyFooPage
    {
        void InputFirstName(string firstName);

        void InputLastName(string lastName);

        void ClickCreate();

        string ReadErrorMessage();
    }
}
