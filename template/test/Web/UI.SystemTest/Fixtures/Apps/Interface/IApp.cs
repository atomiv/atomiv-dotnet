using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Apps.Interface
{
    public interface IApp
    {
        ICreateCustomerPage OpenCreateCustomerPage();
    }
}
