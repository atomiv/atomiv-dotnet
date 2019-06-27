using Optivem.Framework.Infrastructure.Selenium.IntegrationTest.App;
using Optivem.Framework.Test.Selenium;

namespace Optivem.Framework.Infrastructure.Selenium.IntegrationTest.Fixtures
{
    public class SauceDemoFixture
    {
        public SauceDemoFixture()
        {
            Client = new ChromeDriverTestClient();
            Driver = Client.Driver;
            App = new SauceDemoApp(Driver);
        }

        public ChromeDriverTestClient Client { get; }

        public Driver Driver { get; }

        public SauceDemoApp App { get; }

        public void Dispose()
        {
            Driver.Dispose();
        }
    }
}
