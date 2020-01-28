using OpenQA.Selenium;
using Optivem.Atomiv.Core.Common.WebAutomation;
using System.Collections.Generic;

namespace Optivem.Atomiv.Infrastructure.Selenium
{
    public class Driver : Finder, IDriver<ElementRoot, Element, TextBox, CheckBox, ComboBox, Button, RadioButton, RadioButtonGroup, CheckBoxGroup, CompositeElement>
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