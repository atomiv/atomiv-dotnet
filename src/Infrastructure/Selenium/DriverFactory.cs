using Optivem.Framework.Core.Common;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public static class DriverFactory
    {
        private static IFactory<Driver> ChromeDriverFactory = new ChromeDriverFactory();

        private static IFactory<Driver> FirefoxDriverFactory = new FirefoxDriverFactory();

        public static Driver CreateChromeDriver()
        {
            return ChromeDriverFactory.Create();
        }

        public static Driver CreateFirefoxDriver()
        {
            return FirefoxDriverFactory.Create();
        }
    }
}
