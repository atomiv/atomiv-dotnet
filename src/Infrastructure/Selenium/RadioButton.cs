using OpenQA.Selenium;
using Atomiv.Core.Common.WebAutomation;

namespace Atomiv.Infrastructure.Selenium
{
    public class RadioButton : Element, IRadioButton
    {
        public RadioButton(IWebElement element) : base(element)
        {
        }

        public void Select()
        {
            WebElement.Click();
        }

        public bool IsSelected => WebElement.Selected;

        public string Value => WebElement.GetValueAttribute();
    }
}