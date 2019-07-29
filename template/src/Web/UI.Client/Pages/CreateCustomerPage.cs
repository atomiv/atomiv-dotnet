using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Template.Web.UI.Client.Interface.Pages;
using System;

namespace Optivem.Template.Web.UI.Client.Pages
{
    public class CreateCustomerPage : Page, ICreateCustomerPage
    {
        public CreateCustomerPage(Driver driver, string url, bool navigateTo) : base(driver, url, navigateTo)
        {
        }

        public void ClickCreate()
        {
            throw new NotImplementedException();
        }

        public void InputFirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        public void InputLastName(string lastName)
        {
            throw new NotImplementedException();
        }

        public string ReadErrorMessage()
        {
            throw new NotImplementedException();
        }
    }
}
