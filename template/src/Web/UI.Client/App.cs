using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Template.Web.UI.Client.Interface;
using Optivem.Template.Web.UI.Client.Interface.Pages;
using Optivem.Template.Web.UI.Client.Pages;
using System;

namespace Optivem.Template.Web.UI.Client
{
    public class App : App<CreateCustomerPage>, IApp
    {
        public App(Driver finder) : base(finder)
        {
        }

        public ICreateCustomerPage NavigateToCreateCustomerPage()
        {
            return new CreateCustomerPage(Finder, true);
        }
    }
}
