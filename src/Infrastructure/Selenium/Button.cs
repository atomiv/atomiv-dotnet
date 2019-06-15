using OpenQA.Selenium;
using Optivem.Core.Common.WebAutomation;

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
