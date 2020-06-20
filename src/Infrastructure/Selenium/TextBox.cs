using OpenQA.Selenium;
using Atomiv.Core.Common.WebAutomation;

namespace Atomiv.Infrastructure.Selenium
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

        public void InputText(string text)
        {
            WebElement.Clear();
            WebElement.SendKeys(text);
        }
    }
}