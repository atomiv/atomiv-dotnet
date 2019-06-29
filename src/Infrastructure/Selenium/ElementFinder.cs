using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public abstract class ElementFinder : IElementFinder<ElementRoot, Element, TextBox, CheckBox, ComboBox, Button, RadioButton, RadioButtonGroup, CheckBoxGroup>
    {
        private static Func<IWebElement, Button> CreateButton = e => new Button(e);
        private static Func<IWebElement, CheckBox> CreateCheckBox = e => new CheckBox(e);
        private static Func<IWebElement, ComboBox> CreateComboBox = e => new ComboBox(e);
        private static Func<IWebElement, Element> CreateElement = e => new Element(e);
        private static Func<IWebElement, RadioButton> CreateRadioButton = e => new RadioButton(e);
        private static Func<IWebElement, TextBox> CreateTextBox = e => new TextBox(e);

        public Button FindButton(IFindQuery query)
        {
            return FindElement(query, CreateButton);
        }

        public IEnumerable<Button> FindButtons(IFindQuery query)
        {
            return FindElements(query, CreateButton);
        }

        public CheckBox FindCheckBox(IFindQuery query)
        {
            return FindElement(query, CreateCheckBox);
        }

        public IEnumerable<CheckBox> FindCheckBoxes(IFindQuery query)
        {
            return FindElements(query, CreateCheckBox);
        }

        public CheckBoxGroup FindCheckBoxGroup(IFindQuery query)
        {
            var elements = FindCheckBoxes(query);
            return new CheckBoxGroup(elements);
        }

        public ComboBox FindComboBox(IFindQuery query)
        {
            return FindElement(query, CreateComboBox);
        }

        public IEnumerable<ComboBox> FindComboBoxes(IFindQuery query)
        {
            return FindElements(query, CreateComboBox);
        }

        public Element FindElement(IFindQuery query)
        {
            return FindElement(query, CreateElement);
        }

        public IEnumerable<Element> FindElements(IFindQuery query)
        {
            return FindElements(query, CreateElement);
        }

        public RadioButton FindRadioButton(IFindQuery query)
        {
            return FindElement(query, CreateRadioButton);
        }


        public IEnumerable<RadioButton> FindRadioButtons(IFindQuery query)
        {
            return FindElements(query, CreateRadioButton);
        }

        public RadioButtonGroup FindRadioButtonGroup(IFindQuery query)
        {
            var elements = FindRadioButtons(query);
            return new RadioButtonGroup(elements);
        }

        public TextBox FindTextBox(IFindQuery query)
        {
            return FindElement(query, CreateTextBox);
        }

        public IEnumerable<TextBox> FindTextBoxes(IFindQuery query)
        {
            return FindElements(query, CreateTextBox);
        }

        protected abstract IEnumerable<IWebElement> FindWebElements(By by);

        private IEnumerable<T> FindElements<T>(IFindQuery query, Func<IWebElement, T> createElement)
        {
            var by = FindByMap.GetBy(query);
            var webElements = FindWebElements(by);
            var elements = webElements.Select(e => createElement(e)).ToList();
            return elements;
        }

        private T FindElement<T>(IFindQuery query, Func<IWebElement, T> createElement)
        {
            var elements = FindElements(query, createElement);
            return elements.Single();
        }
    }
}
