using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;
using System.Collections.Generic;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public class ElementRoot : Finder, IElementRoot<ElementRoot, Element, TextBox, CheckBox, ComboBox, Button, RadioButton, RadioButtonGroup, CheckBoxGroup, CompositeElement>
    {
        public ElementRoot(Element element)
        {
            Element = element;
        }

        public Element Element { get; }

        public bool Enabled => Element.Enabled;

        public bool Visible => Element.Visible;

        public string Text => Element.Text;

        public string GetAttributeValue(string attribute)
        {
            return Element.GetAttributeValue(attribute);
        }

        protected override IEnumerable<IWebElement> FindWebElements(By by)
        {
            return Element.WebElement.FindElements(by);
        }
    }
}