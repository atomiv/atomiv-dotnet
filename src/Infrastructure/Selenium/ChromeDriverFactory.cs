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
            
            // Use a temporary profile directory to avoid saved passwords and popups
            var tempUserDataDir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "ChromeTestProfile_" + Guid.NewGuid().ToString());
            options.AddArgument($"--user-data-dir={tempUserDataDir}");
            
            // Disable password manager and all security/notification popups
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2);
            
            // Disable Safe Browsing and password leak detection
            options.AddUserProfilePreference("safebrowsing.enabled", false);
            options.AddUserProfilePreference("safebrowsing.enhanced", false);
            options.AddUserProfilePreference("profile.password_manager_leak_detection", false);
            options.AddUserProfilePreference("profile.default_content_setting_values.password_protection_warning_trigger", 2);
            
            // Disable automation detection and Chrome warnings
            options.AddExcludedArgument("enable-automation");
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddArgument("--disable-save-password-bubble");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-infobars");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--password-store=basic");
            options.AddArgument("--use-mock-keychain");
            
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