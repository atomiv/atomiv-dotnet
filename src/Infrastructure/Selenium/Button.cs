using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;

namespace Optivem.Framework.Infrastructure.Selenium
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