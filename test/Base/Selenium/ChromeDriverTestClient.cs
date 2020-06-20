using Atomiv.Infrastructure.Selenium;

namespace Atomiv.Test.Selenium
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