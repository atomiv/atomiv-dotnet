using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Cli.Web.UI.Client.Interface.Pages;

namespace Optivem.Cli.Web.UI.Client.Pages
{
    public class CreateMyFooPage : Page, ICreateMyFooPage
    {
        public CreateMyFooPage(string url, Driver driver, bool navigateTo = false) 
            : base(driver, $"{url}/my-foos/create", navigateTo)
        {
        }

        private Button CreateButton => Finder.FindButton(FindBy.Id("create"));

        private TextBox FirstNameTextBox => Finder.FindTextBox(FindBy.Id("first-name"));

        private TextBox LastNameTextBox => Finder.FindTextBox(FindBy.Id("last-name"));

        private Element ErrorMessageElement => Finder.FindElement(FindBy.Id("error"));

        public void ClickCreate()
        {
            CreateButton.Click();
        }

        public void InputFirstName(string firstName)
        {
            FirstNameTextBox.InputText(firstName);
        }

        public void InputLastName(string lastName)
        {
            LastNameTextBox.InputText(lastName);
        }

        public string ReadErrorMessage()
        {
            return ErrorMessageElement.Text;
        }
    }
}
