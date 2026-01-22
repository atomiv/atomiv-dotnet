using OpenQA.Selenium.Chrome;
using Atomiv.Core.Common;
using System;
using System.IO;
using System.Reflection;

namespace Atomiv.Infrastructure.Selenium
{
    public class ChromeDriverFactory : IFactory<Driver>
    {
        public Driver Create()
        {
            var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            var options = new ChromeOptions();
            
            // Check if running in CI environment
            var isCi = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CI"));
            
            if (isCi)
            {
                // Options for headless CI environment
                options.AddArgument("--headless=new");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-dev-shm-usage");
                options.AddArgument("--disable-gpu");
                options.AddArgument("--window-size=1920,1080");
            }
            
            var webDriver = new ChromeDriver(currentDir, options);
            var driver = new Driver(webDriver);
            return driver;
        }
    }
}