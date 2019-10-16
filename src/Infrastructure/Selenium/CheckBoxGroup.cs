using Optivem.Framework.Core.Common.WebAutomation;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public class CheckBoxGroup : ElementCollection<CheckBox>, ICheckBoxGroup
    {
        public CheckBoxGroup(IEnumerable<CheckBox> elements)
            : base(elements)
        {
        }

        public int Count => Elements.Count();

        public void EnsureValueDeselected(string key)
        {
            var element = Elements.Single(e => e.Value == key);
            element.EnsureDeselected();
        }

        public bool HasSelected()
        {
            return Elements.Any(e => e.IsSelected);
        }

        public List<string> ReadSelectedValues()
        {
            return Elements.Where(e => e.IsSelected)
                .Select(e => e.Value)
                .ToList();
        }

        public string ReadValue(int index)
        {
            var element = Elements.ElementAt(index);
            return element.Value;
        }

        public void EnsureValueSelected(string key)
        {
            var element = Elements.Single(e => e.Value == key);
            element.EnsureSelected();
        }
    }

    // TODO: VC: DELETE

    /*

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

    */
}