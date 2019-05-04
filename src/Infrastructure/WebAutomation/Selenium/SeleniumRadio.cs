using OpenQA.Selenium;
using Optivem.Core.Common.WebAutomation;

namespace Optivem.Framework.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumRadio : BaseSeleniumElement, IRadio
    {
        public SeleniumRadio(IWebElement element) : base(element)
        {
        }

        public void Select()
        {
            Element.Click();
        }

        public bool Selected
        {
            get
            {
                return Element.Selected;
            }
        }
    }
}
