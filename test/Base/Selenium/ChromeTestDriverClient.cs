using Optivem.Framework.Infrastructure.Selenium;

namespace Optivem.Framework.Test.Selenium
{
    public class ChromeTestDriverClient : TestDriverClient
    {
        protected override Driver CreateDriver()
        {
            return DriverFactory.CreateChromeDriver();
        }
    }
}
