using OpenQA.Selenium;
using Optivem.Platform.Core.Common.WebAutomation;

namespace Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumCheckBox : BaseSeleniumElement, ICheckBox
    {
        public SeleniumCheckBox(IWebElement element) : base(element)
        {
        }
    }
}
