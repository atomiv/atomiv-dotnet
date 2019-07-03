using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Pages.Interfaces
{
    public interface ILoginPage
    {
        IProductPage LoginAs(string userName, string password);

        string LoginAsExpectingErrorMessage(string userName, string password);

        void InputUserName(string userName);

        void InputPassword(string password);

        void ClickLogin();
    }
}
