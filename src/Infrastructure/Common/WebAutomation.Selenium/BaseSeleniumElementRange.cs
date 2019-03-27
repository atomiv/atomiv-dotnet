using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium
{
    public class BaseSeleniumElementRange
    {
        public BaseSeleniumElementRange(ReadOnlyCollection<IWebElement> elements)
        {
            Elements = elements;
        }

        public ReadOnlyCollection<IWebElement> Elements { get; private set; }
    }
}
