using OpenQA.Selenium;
using Optivem.Platform.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumRadioGroup<T> : BaseSeleniumElementRange, IRadioGroup<T>
    {
        private Dictionary<string, T> _map;
        private Dictionary<T, string> _reverseMap;

        public SeleniumRadioGroup(ReadOnlyCollection<IWebElement> elements, Dictionary<string, T> map) : base(elements)
        {
            _map = map;
            _reverseMap = map.ToDictionary(e => e.Value, e => e.Key);
        }

        public int Count
        {
            get
            {
                return Elements.Count;
            }
        }

        public T GetSelected()
        {
            var element = Elements.SingleOrDefault(e => e.Selected);

            if(element == null)
            {
                return default(T);
            }

            var rawValue = element.GetAttribute("value");
            var mappedValue = _map[rawValue];
            return mappedValue;
        }

        public T GetValue(int index)
        {
            var element = Elements[index];
            var rawValue = element.GetAttribute("value");
            var mappedValue = _map[rawValue];
            return mappedValue;

            // TODO: VC: Move getting common attributes into some element base
        }

        public bool HasSelected()
        {
            var element = Elements.SingleOrDefault(e => e.Selected);
            return element != null;
        }

        public void Select(T key)
        {
            var mappedValue = _reverseMap[key];
            var element = Elements.Single(e => e.GetAttribute("value") == mappedValue);
            element.Click();
        }
    }
}
