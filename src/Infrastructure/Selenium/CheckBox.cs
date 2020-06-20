using OpenQA.Selenium;
using Atomiv.Core.Common.WebAutomation;

namespace Atomiv.Infrastructure.Selenium
{
    public class CheckBox : Element, ICheckBox
    {
        public CheckBox(IWebElement element) : base(element)
        {
        }

        public string Value => WebElement.GetValueAttribute();

        public bool IsSelected => WebElement.Selected;

        public void Click()
        {
            WebElement.Click();
        }

        public void EnsureDeselected()
        {
            if (IsSelected)
            {
                Click();
            }
        }

        public void EnsureSelected()
        {
            if (!IsSelected)
            {
                Click();
            }
        }
    }
}