using OpenQA.Selenium;
using Optivem.Atomiv.Core.Common.WebAutomation;

namespace Optivem.Atomiv.Infrastructure.Selenium
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