using Optivem.Framework.Core.Common.WebAutomation;
using Optivem.Framework.Infrastructure.Selenium;

namespace Optivem.Framework.Test.Xunit.Selenium
{
    public class ChromeDriverFixture : DriverFixture
    {
        protected override IDriver CreateDriver()
        {
            return DriverFactory.CreateChromeDriver();
        }
    }
}
