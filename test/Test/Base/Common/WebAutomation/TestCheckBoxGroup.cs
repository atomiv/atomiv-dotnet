using Optivem.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Test.Common.WebAutomation
{
    public class TestCheckBoxGroup<T> : ICheckBoxGroup<T>
    {
        private readonly ICheckBoxGroup<T> _checkBoxGroup;

        public TestCheckBoxGroup(ICheckBoxGroup<T> checkBoxGroup)
        {
            _checkBoxGroup = checkBoxGroup;
        }

        public int Count => _checkBoxGroup.Count;

        public void Deselect(T key)
        {
            _checkBoxGroup.Deselect(key);
        }

        public List<T> ReadSelected()
        {
            return _checkBoxGroup.ReadSelected();
        }

        public T ReadValue(int index)
        {
            return _checkBoxGroup.ReadValue(index);
        }

        public bool HasSelected()
        {
            return _checkBoxGroup.HasSelected();
        }

        public void Select(T key)
        {
            _checkBoxGroup.Select(key);
        }
    }
}
