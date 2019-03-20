using OpenQA.Selenium;
using Optivem.Platform.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumTextBox : ITextBox
    {
        private IWebElement _element;

        public SeleniumTextBox(IWebElement element)
        {
            _element = element;
        }

        public string GetText()
        {
            return _element.GetAttribute("value");
        }

        public void SetText(string text)
        {
            _element.Clear();
            _element.SendKeys(text);
        }

        // TODO: VC: Protected --> IWebElement or public?

        /*
         * 
            var element = driver.FindElement(By.Name("firstname"));
            element.Clear();
            element.SendKeys("This is my name");


            var value = element.GetAttribute("value");
         * 
         */
    }
}
