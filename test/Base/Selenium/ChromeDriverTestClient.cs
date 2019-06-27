using Optivem.Framework.Infrastructure.Selenium;

namespace Optivem.Framework.Test.Selenium
{
    public class ChromeDriverTestClient
    {
        public ChromeDriverTestClient()
        {
            var factory = new ChromeDriverFactory();
            Driver = factory.Create();
        }

        public Driver Driver { get; }
    }
}
