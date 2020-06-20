using OpenQA.Selenium;
using Atomiv.Core.Common.WebAutomation;

namespace Atomiv.Infrastructure.Selenium
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

        public string Text => WebElement.Text;

        public string GetAttributeValue(string attribute)
        {
            return WebElement.GetAttribute(attribute);
        }
    }
}