using Optivem.Core.Common.WebAutomation;
using Optivem.Infrastructure.Selenium;

namespace Optivem.Test.Xunit.Selenium
{
    public class ChromeDriverFixture : DriverFixture
    {
        protected override IDriver CreateDriver()
        {
            return DriverFactory.CreateChromeDriver();
        }
    }
}
