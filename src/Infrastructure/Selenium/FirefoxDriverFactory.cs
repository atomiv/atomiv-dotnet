using OpenQA.Selenium.Firefox;
using Optivem.Atomiv.Core.Common;
using System.IO;
using System.Reflection;

namespace Optivem.Atomiv.Infrastructure.Selenium
{
    public class FirefoxDriverFactory : IFactory<Driver>
    {
        // TODO: VC: Check if works

        public Driver Create()
        {
            var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var webDriver = new FirefoxDriver(currentDir);
            var driver = new Driver(webDriver);
            return driver;
        }
    }
}