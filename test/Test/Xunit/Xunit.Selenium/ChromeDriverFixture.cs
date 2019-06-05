using OpenQA.Selenium;
using Optivem.Core.Common.WebAutomation;
using Optivem.Infrastructure.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

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
