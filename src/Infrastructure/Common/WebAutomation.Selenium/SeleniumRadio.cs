using OpenQA.Selenium;
using Optivem.Platform.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumRadio : BaseSeleniumElement, IRadio
    {
        public SeleniumRadio(IWebElement element) : base(element)
        {
        }

        public void Select()
        {
            Element.Click();
        }

        public bool Selected
        {
            get
            {
                return Element.Selected;
            }
        }
    }
}
