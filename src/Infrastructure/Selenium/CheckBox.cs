using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public class CheckBox : Element, ICheckBox
    {
        public CheckBox(IWebElement element) : base(element)
        {
        }
    }
}