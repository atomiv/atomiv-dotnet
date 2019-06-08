using OpenQA.Selenium;
using Optivem.Core.Common.WebAutomation;

namespace Optivem.Infrastructure.Selenium
{
    public class Element : IElement
    {
        public Element(IWebElement element)
        {
            WebElement = element;
        }

        public IWebElement WebElement { get; private set; }

        public bool Enabled => WebElement.Enabled;

        public bool Visible => WebElement.Displayed;
    }
}