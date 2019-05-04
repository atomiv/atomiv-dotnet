using OpenQA.Selenium;
using Optivem.Common.WebAutomation;

namespace Optivem.Infrastructure.WebAutomation.Selenium
{
    public class SeleniumCheckBox : BaseSeleniumElement, ICheckBox
    {
        public SeleniumCheckBox(IWebElement element) : base(element)
        {
        }
    }
}
