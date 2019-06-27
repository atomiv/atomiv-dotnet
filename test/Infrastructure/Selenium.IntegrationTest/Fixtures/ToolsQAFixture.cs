using Optivem.Framework.Infrastructure.Selenium.IntegrationTest.App;
using Optivem.Framework.Test.Selenium;

namespace Optivem.Framework.Infrastructure.Selenium.IntegrationTest.Fixtures
{
    public class ToolsQAFixture
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
