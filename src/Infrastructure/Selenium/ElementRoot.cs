using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public class ElementRoot : ElementFinder, IElementRoot<ElementRoot, Element, TextBox, CheckBox, ComboBox, Button, RadioButton, RadioButtonGroup, CheckBoxGroup>
    {
        public ElementRoot(Element element)
        {
            Element = element;
        }

        public Element Element { get; }

        public bool Enabled => Element.Enabled;

        public bool Visible => Element.Visible;

        public string Text => Element.Text;

        protected override IEnumerable<IWebElement> FindWebElements(By by)
        {
            return Element.WebElement.FindElements(by);
        }
    }
}
