using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;

namespace Optivem.Framework.Infrastructure.Selenium
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