using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Framework.Test.Selenium;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Data;
using Optivem.Template.Web.UI.SystemTest.Fixtures.Interfaces;
using System;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures
{
    public class AppFixture : IDisposable
    {
        public AppFixture()
        {
            Db = new FakeDatabase();
            Client = new ChromeDriverTestClient();
            Driver = Client.Driver;
            App = new App(Driver);
        }

        public IDatabase Db { get; }

        public ChromeDriverTestClient Client { get; }

        public Driver Driver { get; }

        public IApp App { get; }

        public void Dispose()
        {
            Driver.Dispose();
        }
    }
}
