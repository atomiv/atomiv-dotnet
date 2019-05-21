using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Optivem.Common.WebAutomation;
using Optivem.Infrastructure.WebAutomation.Selenium;
using System;
using System.IO;
using System.Reflection;

namespace Optivem.Framework.Infrastructure.Common.WebAutomation.Selenium.Test
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