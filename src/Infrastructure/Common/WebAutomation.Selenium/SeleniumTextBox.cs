using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;

namespace Optivem.Framework.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumTextBox : BaseSeleniumElement, ITextBox
    {
        public SeleniumTextBox(IWebElement element) : base(element)
        {
        }

        public string GetText()
        {
            return Element.GetAttribute("value");
        }

        public void SetText(string text)
        {
            Element.Clear();
            Element.SendKeys(text);
        }

        // TODO: VC: Protected --> IWebElement or public?

        /*
         * 
            var element = driver.FindElement(By.Name("firstname"));
            element.Clear();
            element.SendKeys("This is my name");


            var value = element.GetAttribute("value");
         * 
         */
    }
}
