using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Framework.Test.Selenium;
using Optivem.Template.Web.UI.Client;
using Optivem.Template.Web.UI.Client.Interface;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures
{
    public class AppFixture : IAppFixture
    {
        private ChromeDriverTestClient Client;

        private Driver Driver { get; }

        public AppFixture()
        {
            var webUiUrl = "https://localhost:5109";

            Client = new ChromeDriverTestClient();
            Driver = Client.Driver;

            App = new App(Driver, webUiUrl);
        }

        public IApp App { get; }

        public void Dispose()
        {
            Driver.Dispose();
        }
    }
}