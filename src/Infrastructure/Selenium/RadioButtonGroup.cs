using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;
using System.Collections.ObjectModel;
using System.Linq;

namespace Optivem.Framework.Infrastructure.Selenium
{
    // TODO: VC: CONTINUE


    public class RadioButtonGroup : ElementCollection, IRadioButtonGroup
    {
        public RadioButtonGroup(ReadOnlyCollection<IWebElement> elements) 
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

        public string ReadSelectedValue()
        {
            var element = Elements.SingleOrDefault(e => e.Selected);

            if (element == null)
            {
                return null;
            }

            var value = element.GetValueAttribute();
            return value;
        }

        public string ReadValue(int index)
        {
            var element = Elements[index];
            var value = element.GetValueAttribute();
            return value;

            // TODO: VC: Move getting common attributes into some element base
        }

        public bool HasSelected()
        {
            var element = Elements.SingleOrDefault(e => e.Selected);
            return element != null;
        }

        public void SelectValue(string key)
        {
            var element = Elements.Single(e => e.GetValueAttribute() == key);
            element.Click();
        }
    }

    // TODO: VC: DELETE

    /*

    public class RadioGroup<T> : RadioGroup, IRadioGroup<T>
    {
        private Dictionary<string, T> _map;
        private Dictionary<T, string> _reverseMap;

        public RadioGroup(ReadOnlyCollection<IWebElement> elements, Dictionary<string, T> map) 
            : base(elements)
        {
            _map = map;
            _reverseMap = map.ToDictionary(e => e.Value, e => e.Key);
        }


        public T ReadSelected()
        {
            var rawValue = ReadSelectedValue();
            var mappedValue = _map[rawValue];
            return mappedValue;
        }

        public T Read(int index)
        {
            var rawValue = ReadValue(index);
            var mappedValue = _map[rawValue];
            return mappedValue;

            // TODO: VC: Move getting common attributes into some element base
        }

        public void Select(T key)
        {
            var mappedValue = _reverseMap[key];
            SelectValue(mappedValue);
        }
    }

    */


}