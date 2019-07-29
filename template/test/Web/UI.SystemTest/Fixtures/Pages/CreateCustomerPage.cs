using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Pages
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
