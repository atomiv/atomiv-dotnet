using OpenQA.Selenium;
using Optivem.Core.Common.WebAutomation;

namespace Optivem.Infrastructure.Selenium
{
    public class CheckBox : Element, ICheckBox
    {
        public CheckBox(IWebElement element) : base(element)
        {
        }
    }
}