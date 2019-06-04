using OpenQA.Selenium;
using Optivem.Core.Common.WebAutomation;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Infrastructure.Selenium
{
    public class ComboBox : BaseElement, IComboBox
    {
        public ComboBox(IWebElement element) 
            : base(element)
        {
        }

        public int Count
        {
            get
            {
                return Element.FindElements(By.TagName("option")).Count;
            }
        }

        public bool HasSelected()
        {
            var element = Element.FindElements(By.TagName("option")).SingleOrDefault(e => e.Selected);
            return element != null;
        }

        public string ReadSelectedValue()
        {
            var element = Element.FindElements(By.TagName("option")).SingleOrDefault(e => e.Selected);

            if (element == null)
            {
                return null;
            }

            return element.GetValueAttribute();
        }

        public string ReadValue(int index)
        {
            var element = Element.FindElements(By.TagName("option"))[index];
            return element.GetValueAttribute();

            // TODO: VC: Move getting common attributes into some element base
        }

        public void SelectValue(string key)
        {
            var element = Element.FindElements(By.TagName("option")).Single(e => e.GetValueAttribute() == key);
            element.Click();
        }
    }

    public class ComboBox<T> : ComboBox, IComboBox<T>
    {
        private Dictionary<string, T> _map;
        private Dictionary<T, string> _reverseMap;

        public ComboBox(IWebElement element, Dictionary<string, T> map) : base(element)
        {
            _map = map;
            _reverseMap = map.ToDictionary(e => e.Value, e => e.Key);
        }

        public T ReadSelected()
        {
            var value = ReadSelectedValue();
            return _map[value];
        }

        public T Read(int index)
        {
            var value = ReadValue(index);
            return _map[value];
        }

        public void Select(T key)
        {
            var value = _reverseMap[key];
            SelectValue(value);
        }
    }
}