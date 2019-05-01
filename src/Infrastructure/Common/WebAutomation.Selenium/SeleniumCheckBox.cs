using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;

namespace Optivem.Framework.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumCheckBox : BaseSeleniumElement, ICheckBox
    {
        public SeleniumCheckBox(IWebElement element) : base(element)
        {
        }
    }
}
