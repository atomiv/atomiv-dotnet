using OpenQA.Selenium;
using Optivem.Core.Common.WebAutomation;

namespace Optivem.Infrastructure.Selenium
{
    public class Radio : BaseElement, IRadio
    {
        public Radio(IWebElement element) : base(element)
        {
        }

        public void Select()
        {
            Element.Click();
        }

        public bool IsSelected
        {
            get
            {
                return Element.Selected;
            }
        }
    }
}