using Optivem.Atomiv.Infrastructure.Selenium.SystemTest.Fixtures.Data;
using Optivem.Atomiv.Infrastructure.Selenium.SystemTest.Fixtures.Interfaces;
using Optivem.Atomiv.Test.Selenium;
using System;

namespace Optivem.Atomiv.Infrastructure.Selenium.SystemTest.Fixtures
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