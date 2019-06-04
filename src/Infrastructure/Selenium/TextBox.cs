using OpenQA.Selenium;
using Optivem.Core.Common.WebAutomation;

namespace Optivem.Infrastructure.Selenium
{
    public class TextBox : BaseElement, ITextBox
    {
        public TextBox(IWebElement element) : base(element)
        {
        }

        public string ReadText()
        {
            return Element.GetAttribute("value");
        }

        public void EnterText(string text)
        {
            Element.Clear();
            Element.SendKeys(text);
        }
    }
}