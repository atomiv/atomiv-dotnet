using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;

namespace Optivem.Framework.Infrastructure.Selenium
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