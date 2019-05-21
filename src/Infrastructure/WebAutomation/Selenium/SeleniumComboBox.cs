using OpenQA.Selenium;
using Optivem.Common.WebAutomation;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Infrastructure.WebAutomation.Selenium
{
    public class SeleniumComboBox<T> : BaseSeleniumElement, IComboBox<T>
    {
        private Dictionary<string, T> _map;
        private Dictionary<T, string> _reverseMap;

        public SeleniumComboBox(IWebElement element, Dictionary<string, T> map) : base(element)
        {
            _map = map;
            _reverseMap = map.ToDictionary(e => e.Value, e => e.Key);
        }

        public int Count
        {
            get
            {
                return Element.FindElements(By.TagName("option")).Count;
            }
        }

        public T GetSelected()
        {
            var element = Element.FindElements(By.TagName("option")).SingleOrDefault(e => e.Selected);

            if (element == null)
            {
                return default(T);
            }

            var rawValue = element.GetAttribute("value");
            var mappedValue = _map[rawValue];
            return mappedValue;
        }

        public T GetValue(int index)
        {
            var element = Element.FindElements(By.TagName("option"))[index];
            var rawValue = element.GetAttribute("value");
            var mappedValue = _map[rawValue];
            return mappedValue;

            // TODO: VC: Move getting common attributes into some element base
        }

        public bool HasSelected()
        {
            var element = Element.FindElements(By.TagName("option")).SingleOrDefault(e => e.Selected);
            return element != null;
        }

        public void Select(T key)
        {
            var mappedValue = _reverseMap[key];
            var element = Element.FindElements(By.TagName("option")).Single(e => e.GetAttribute("value") == mappedValue);
            element.Click();
        }
    }
}