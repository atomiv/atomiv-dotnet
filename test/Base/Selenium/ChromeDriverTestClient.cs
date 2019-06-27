using Optivem.Framework.Infrastructure.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Test.Selenium
{
    public class ChromeDriverTestClient
    {
        public ChromeDriverTestClient()
        {
            var factory = new ChromeDriverFactory();
            Driver = factory.Create();
        }

        public Driver Driver { get; }
    }
}
