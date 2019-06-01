using OpenQA.Selenium;
using Optivem.Core.Common.WebAutomation;

namespace Optivem.Infrastructure.Selenium
{
    public class SeleniumCheckBox : BaseSeleniumElement, ICheckBox
    {
        public SeleniumCheckBox(IWebElement element) : base(element)
        {
        }
    }
}