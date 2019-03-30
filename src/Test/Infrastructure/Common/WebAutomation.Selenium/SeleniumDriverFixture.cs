using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Optivem.Platform.Core.Common.WebAutomation;
using Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Optivem.Platform.Test.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumDriverFixture : IDisposable
    {
        // TODO: VC: Use Ioc / DI, so that we could specify Chrome, Firefox, etc.

        private readonly IWebDriver _webDriver;

        public SeleniumDriverFixture()
        {
            var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _webDriver = new ChromeDriver(currentDir);
            Driver = new SeleniumDriver(_webDriver);

            // TODO: VC: Check if the top Driver should do the disposal, and construction...
        }

        public IDriver Driver { get; }

        public void Dispose()
        {
            _webDriver.Dispose();
        }
    }
}
