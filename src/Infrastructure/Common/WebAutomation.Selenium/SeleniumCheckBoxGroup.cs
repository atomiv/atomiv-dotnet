using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Optivem.Framework.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumCheckBoxGroup<T> : BaseSeleniumElementRange, ICheckBoxGroup<T>
    {
        private Dictionary<string, T> _map;
        private Dictionary<T, string> _reverseMap;

        public SeleniumCheckBoxGroup(ReadOnlyCollection<IWebElement> elements, Dictionary<string, T> map) : base(elements)
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
        
        public List<T> GetSelected()
        {
            return Elements.Where(e => e.Selected).Select(e => _map[e.GetAttribute("value")]).ToList();
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

            if(!element.Selected)
            {
                element.Click();
            }
        }

        public void Deselect(T key)
        {
            var mappedValue = _reverseMap[key];
            var element = Elements.Single(e => e.GetAttribute("value") == mappedValue);

            if (element.Selected)
            {
                element.Click();
            }
        }
    }
}
