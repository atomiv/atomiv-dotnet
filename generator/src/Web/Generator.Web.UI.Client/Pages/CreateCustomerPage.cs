using Atomiv.Infrastructure.Selenium;
using Generator.Web.UI.Client.Interface.Pages;

namespace Generator.Web.UI.Client.Pages
{
    public class CreateCustomerPage : Page, ICreateCustomerPage
    {
        public CreateCustomerPage(string url, Driver driver, bool navigateTo = false) 
            : base(driver, $"{url}/customers/create", navigateTo)
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
