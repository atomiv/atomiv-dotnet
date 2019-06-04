using OpenQA.Selenium;
using Optivem.Core.Common.WebAutomation;

namespace Optivem.Infrastructure.Selenium
{
    public class TextBox : BaseElement, ITextBox
    {
        public TextBox(IWebElement element) : base(element)
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
    }
}