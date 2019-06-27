using Optivem.Framework.Test.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures
{
    public class SauceDemoFixture : IDisposable
    {
        public SauceDemoFixture()
        {
            Client = new ChromeTestDriverClient();
            TestDriver = Client.TestDriver;
            App = new SauceDemoApp(TestDriver);
        }

        public ChromeTestDriverClient Client { get; }

        public TestDriver TestDriver { get; }

        public SauceDemoApp App { get; }

        public void Dispose()
        {
            TestDriver.Dispose();
        }
    }
}
