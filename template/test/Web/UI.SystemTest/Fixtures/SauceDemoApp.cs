using Optivem.Framework.Test.Common.WebAutomation;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures
{
    public class SauceDemoApp : TestPageObject
    {
        public SauceDemoApp(TestDriver driver)
            : base(driver)
        {
        }

        public SauceDemoLoginPage OpenLoginScreen()
        {
            return SauceDemoLoginPage.Open(Driver);
        }

        public SauceDemoLoginPage LoginScreen => new SauceDemoLoginPage(Driver);

        public SauceDemoInventoryPage InventoryScreen => new SauceDemoInventoryPage(Driver);
    }
}
