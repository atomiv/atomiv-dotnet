using OpenQA.Selenium.Chrome;
using Atomiv.Core.Common;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace Atomiv.Infrastructure.Selenium
{
    public class ChromeDriverFactory : IFactory<Driver>
    {
        public Driver Create()
        {
            // Automatically download and setup ChromeDriver matching the installed Chrome version
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            
            var options = new ChromeOptions();
            
            // Disable password manager and security popups
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddArgument("--disable-save-password-bubble");
            
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
            
            var webDriver = new ChromeDriver(options);
            
            // Set timeouts to handle slower page loads in CI
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
            webDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
            
            var driver = new Driver(webDriver);
            return driver;
        }
    }
}