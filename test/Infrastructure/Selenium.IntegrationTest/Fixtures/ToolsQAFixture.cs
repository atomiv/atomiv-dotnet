using Atomiv.Infrastructure.Selenium.IntegrationTest.App;
using Atomiv.Test.Selenium;
using System;

namespace Atomiv.Infrastructure.Selenium.IntegrationTest.Fixtures
{
    public class ToolsQAFixture : IDisposable
    {
        public ToolsQAFixture()
        {
            Client = new ChromeDriverTestClient();
            Driver = Client.Driver;
            App = new ToolsQAApp(Driver);
        }

        public ChromeDriverTestClient Client { get; }

        public Driver Driver { get; }

        public ToolsQAApp App { get; }

        public void Dispose()
        {
            Driver.Dispose();
        }
    }
}