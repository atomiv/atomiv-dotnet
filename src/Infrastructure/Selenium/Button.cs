using OpenQA.Selenium;
using Atomiv.Core.Common.WebAutomation;

namespace Atomiv.Infrastructure.Selenium
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