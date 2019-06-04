using OpenQA.Selenium;
using Optivem.Core.Common.WebAutomation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Optivem.Infrastructure.Selenium
{
    public class CheckBoxGroup : BaseElementRange, ICheckBoxGroup
    {
        public CheckBoxGroup(ReadOnlyCollection<IWebElement> elements) 
            : base(elements)
        {
        }

        public int Count
        {
            get
            {
                return Elements.Count;
            }
        }

        public void DeselectValue(string key)
        {
            var element = Elements.Single(e => e.GetValueAttribute() == key);

            if (element.Selected)
            {
                element.Click();
            }
        }

        public bool HasSelected()
        {
            var element = Elements.SingleOrDefault(e => e.Selected);
            return element != null;
        }

        public List<string> ReadSelectedValues()
        {
            return Elements.Where(e => e.Selected)
                .Select(e => e.GetValueAttribute())
                .ToList();
        }

        public string ReadValue(int index)
        {
            var element = Elements[index];
            return element.GetValueAttribute();
        }

        public void SelectValue(string key)
        {
            var element = Elements.Single(e => e.GetValueAttribute() == key);

            if (!element.Selected)
            {
                element.Click();
            }
        }
    }

    public class CheckBoxGroup<T> : CheckBoxGroup, ICheckBoxGroup<T>
    {
        private Dictionary<string, T> _map;
        private Dictionary<T, string> _reverseMap;

        public CheckBoxGroup(ReadOnlyCollection<IWebElement> elements, Dictionary<string, T> map) 
            : base(elements)
        {
            _map = map;
            _reverseMap = map.ToDictionary(e => e.Value, e => e.Key);
        }

        public List<T> ReadSelected()
        {
            var values = ReadSelectedValues();
            return values.Select(e => _map[e]).ToList();
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

        public void Deselect(T key)
        {
            var value = _reverseMap[key];
            DeselectValue(value);
        }
    }
}