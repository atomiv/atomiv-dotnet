using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public abstract class Finder : IFinder<ElementRoot, Element, TextBox, CheckBox, ComboBox, Button, RadioButton, RadioButtonGroup, CheckBoxGroup, CompositeElement>
    {
        private static Func<ElementRoot, Button> CreateButton = e => new Button(e.Element.WebElement);
        private static Func<ElementRoot, CheckBox> CreateCheckBox = e => new CheckBox(e.Element.WebElement);
        private static Func<ElementRoot, ComboBox> CreateComboBox = e => new ComboBox(e.Element.WebElement);
        private static Func<ElementRoot, Element> CreateElement = e => new Element(e.Element.WebElement);
        private static Func<ElementRoot, RadioButton> CreateRadioButton = e => new RadioButton(e.Element.WebElement);
        private static Func<ElementRoot, TextBox> CreateTextBox = e => new TextBox(e.Element.WebElement);

        private static Type ElementRootType = typeof(ElementRoot);

        public Button FindButton(IQuery query)
        {
            return FindElement(query, CreateButton);
        }

        public IEnumerable<Button> FindButtons(IQuery query)
        {
            return FindElements(query, CreateButton);
        }

        public CheckBox FindCheckBox(IQuery query)
        {
            return FindElement(query, CreateCheckBox);
        }

        public IEnumerable<CheckBox> FindCheckBoxes(IQuery query)
        {
            return FindElements(query, CreateCheckBox);
        }

        public CheckBoxGroup FindCheckBoxGroup(IQuery query)
        {
            var elements = FindCheckBoxes(query);
            return new CheckBoxGroup(elements);
        }

        public ComboBox FindComboBox(IQuery query)
        {
            return FindElement(query, CreateComboBox);
        }

        public IEnumerable<ComboBox> FindComboBoxes(IQuery query)
        {
            return FindElements(query, CreateComboBox);
        }

        public Element FindElement(IQuery query)
        {
            return FindElement(query, CreateElement);
        }

        public IEnumerable<Element> FindElements(IQuery query)
        {
            return FindElements(query, CreateElement);
        }

        public RadioButton FindRadioButton(IQuery query)
        {
            return FindElement(query, CreateRadioButton);
        }


        public IEnumerable<RadioButton> FindRadioButtons(IQuery query)
        {
            return FindElements(query, CreateRadioButton);
        }

        public RadioButtonGroup FindRadioButtonGroup(IQuery query)
        {
            var elements = FindRadioButtons(query);
            return new RadioButtonGroup(elements);
        }

        public TextBox FindTextBox(IQuery query)
        {
            return FindElement(query, CreateTextBox);
        }

        public IEnumerable<TextBox> FindTextBoxes(IQuery query)
        {
            return FindElements(query, CreateTextBox);
        }

        public IEnumerable<T> FindElements<T>(IQuery query, Func<ElementRoot, T> createElement)
        {
            var by = FindByMap.GetBy(query);
            var webElements = FindWebElements(by);
            var baseElements = webElements.Select(e => new ElementRoot(new Element(e))).ToList();
            var specificElements = baseElements.Select(e => createElement(e)).ToList();
            return specificElements;
        }

        public T FindElement<T>(IQuery query, Func<ElementRoot, T> createElement)
        {
            var elements = FindElements(query, createElement);
            return elements.Single();
        }

        protected abstract IEnumerable<IWebElement> FindWebElements(By by);

        public IEnumerable<T> FindElements<T>(IQuery query) where T : CompositeElement
        {
            Func<ElementRoot, T> createElement = e => Create<T>(e);
            return FindElements(query, createElement);
        }

        public T FindElement<T>(IQuery query) where T : CompositeElement
        {
            Func<ElementRoot, T> createElement = e => Create<T>(e);
            return FindElement(query, createElement);
        }

        private static T Create<T>(ElementRoot element) where T : CompositeElement
        {
            var type = typeof(T);
            var constructorInfo = type.GetConstructor(new[] { ElementRootType });
            var obj = constructorInfo.Invoke(new object[] { element });
            return (T)obj;
        }


    }
}
