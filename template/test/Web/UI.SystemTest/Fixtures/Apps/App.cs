using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Apps.Interface;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures
{
    public class App : App<CreateCustomerPage>, IApp
    {
        public App(Driver finder) : base(finder)
        {
        }

        public ICreateCustomerPage OpenCreateCustomerPage()
        {
            throw new NotImplementedException();
        }
    }
}
