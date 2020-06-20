using OpenQA.Selenium.Chrome;
using Atomiv.Core.Common;
using System.IO;
using System.Reflection;

namespace Atomiv.Infrastructure.Selenium
{
    public class ChromeDriverFactory : IFactory<Driver>
    {
        public Driver Create()
        {
            var currentDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var webDriver = new ChromeDriver(currentDir);
            var driver = new Driver(webDriver);
            return driver;
        }
    }
}