using Optivem.Framework.Infrastructure.Selenium;

namespace Optivem.Framework.Test.Selenium
{
    public class ChromeDriverFixture : DriverFixture
    {
        protected override Driver CreateDriver()
        {
            return DriverFactory.CreateChromeDriver();
        }
    }
}
