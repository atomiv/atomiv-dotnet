using OpenQA.Selenium;
using Optivem.Core.Common.WebAutomation;

namespace Optivem.Infrastructure.Selenium
{
    public class Radio : Element, IRadioButton
    {
        public Radio(IWebElement element) : base(element)
        {
        }

        public void Select()
        {
            WebElement.Click();
        }

        public bool IsSelected
        {
            get
            {
                return WebElement.Selected;
            }
        }
    }
}