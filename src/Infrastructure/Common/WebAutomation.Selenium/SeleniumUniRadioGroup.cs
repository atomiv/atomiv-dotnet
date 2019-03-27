using OpenQA.Selenium;
using Optivem.Platform.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumUniRadioGroup<T> : BaseSeleniumElementRange, IRadioGroup<T>
    {
        private Dictionary<string, T> _map;
        private Dictionary<T, string> _reverseMap;

        public SeleniumUniRadioGroup(ReadOnlyCollection<IWebElement> elements, Dictionary<string, T> map) : base(elements)
        {
            _map = map;
            _reverseMap = map.ToDictionary(e => e.Value, e => e.Key);
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
