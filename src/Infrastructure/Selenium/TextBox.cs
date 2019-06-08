using OpenQA.Selenium;
using Optivem.Core.Common.WebAutomation;

namespace Optivem.Infrastructure.Selenium
{
    public class TextBox : Element, ITextBox
    {
        public TextBox(IWebElement element) : base(element)
        {
        }

        public string ReadText()
        {
            return WebElement.GetAttribute("value");
        }

        public void EnterText(string text)
        {
            WebElement.Clear();
            WebElement.SendKeys(text);
        }
    }
}