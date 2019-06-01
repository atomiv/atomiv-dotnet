using OpenQA.Selenium;
using Optivem.Core.Common.WebAutomation;

namespace Optivem.Infrastructure.Selenium
{
    public abstract class BaseSeleniumElement : IElement
    {
        public BaseSeleniumElement(IWebElement element)
        {
            Element = element;
        }

        public IWebElement Element { get; private set; }

        public bool Enabled => Element.Enabled;

        public bool Visible => Element.Displayed;
    }
}