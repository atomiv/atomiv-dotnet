using OpenQA.Selenium;
using Optivem.Platform.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumFinder : IFinder
    {
        private IWebDriver _webDriver;

        public SeleniumFinder(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public ITextBox FindTextBoxByName(string name)
        {
            var locator = By.Name(name);
            var element = _webDriver.FindElement(locator);
            return new SeleniumTextBox(element);
        }
    }
}
