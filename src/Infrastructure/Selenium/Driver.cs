using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public class Driver : ElementFinder, IDriver<ElementRoot, Element, TextBox, CheckBox, ComboBox, Button, RadioButton, RadioButtonGroup, CheckBoxGroup> // TODO: VC: DELETE, IDriver
    {
        public Driver(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebDriver WebDriver { get; private set; }

        public string Url
        {
            get { return WebDriver.Url; }
            set { WebDriver.Url = value; }
        }


        public void Dispose()
        {
            WebDriver.Dispose();
        }


        protected override IEnumerable<IWebElement> FindWebElements(By by)
        {
            return WebDriver.FindElements(by);
        }
    }
}