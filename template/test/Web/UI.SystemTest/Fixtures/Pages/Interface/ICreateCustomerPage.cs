using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Pages.Interface
{
    public interface ICreateCustomerPage
    {
        void InputFirstName(string firstName);

        void InputLastName(string lastName);

        void ClickCreate();

        string ReadErrorMessage();
    }
}
