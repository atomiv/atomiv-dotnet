using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Optivem.Platform.Test.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumFixture : IDisposable
    {
        // TODO: VC: Use Ioc / DI, so that we could specify Chrome, Firefox, etc.

        public SeleniumFixture()
        {
            var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            WebDriver = new ChromeDriver(currentDir);
        }

        public IWebDriver WebDriver { get; }

        public void Dispose()
        {
            WebDriver.Dispose();
        }
    }
}
