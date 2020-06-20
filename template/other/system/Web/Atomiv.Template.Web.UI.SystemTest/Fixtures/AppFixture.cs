using Atomiv.Infrastructure.Selenium;
using Atomiv.Test.Selenium;
using Atomiv.Template.Web.UI.Client;
using Atomiv.Template.Web.UI.Client.Interface;

namespace Atomiv.Template.Web.UI.SystemTest.Fixtures
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