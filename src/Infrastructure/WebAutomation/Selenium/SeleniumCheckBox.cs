using OpenQA.Selenium;
using Optivem.Common.WebAutomation;

namespace Optivem.Infrastructure.Selenium
{
    public class SeleniumCheckBox : BaseSeleniumElement, ICheckBox
    {
        public SeleniumCheckBox(IWebElement element) : base(element)
        {
        }
    }
}