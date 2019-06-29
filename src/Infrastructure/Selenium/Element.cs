using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;

namespace Optivem.Framework.Infrastructure.Selenium
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
    }
}