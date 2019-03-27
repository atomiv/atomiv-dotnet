using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium
{
    public abstract class BaseSeleniumElement
    {
        public BaseSeleniumElement(IWebElement element)
        {
            Element = element;
        }

        public IWebElement Element { get; private set; }
    }
}
