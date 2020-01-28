using OpenQA.Selenium;
using Optivem.Atomiv.Core.Common.WebAutomation;

namespace Optivem.Atomiv.Infrastructure.Selenium
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