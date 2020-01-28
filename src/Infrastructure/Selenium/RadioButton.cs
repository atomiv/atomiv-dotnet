using OpenQA.Selenium;
using Optivem.Atomiv.Core.Common.WebAutomation;

namespace Optivem.Atomiv.Infrastructure.Selenium
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