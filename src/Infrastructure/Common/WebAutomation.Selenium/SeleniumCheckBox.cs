using OpenQA.Selenium;
using Optivem.Platform.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumCheckBox : ICheckBox
    {
        private IWebElement _element;

        public SeleniumCheckBox(IWebElement element)
        {
            _element = element;
        }
    }
}
