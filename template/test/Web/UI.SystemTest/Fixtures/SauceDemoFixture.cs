using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Framework.Test.Selenium;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Data;
using System;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures
{
    public class SauceDemoFixture : IDisposable
    {
        public SauceDemoFixture()
        {
            Db = new FakeDatabase();
            Client = new ChromeDriverTestClient();
            Driver = Client.Driver;
            App = new SauceDemoApp(Driver);
        }

        public IDatabase Db { get; }

        public ChromeDriverTestClient Client { get; }

        public Driver Driver { get; }

        public SauceDemoApp App { get; }

        public void Dispose()
        {
            Driver.Dispose();
        }
    }
}
