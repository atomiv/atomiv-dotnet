using OpenQA.Selenium;
using Optivem.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Infrastructure.Selenium
{
    public class Button : Element, IButton
    {
        public Button(IWebElement element) 
            : base(element)
        {
        }

        public void Click()
        {
            WebElement.Click();
        }
    }
}
