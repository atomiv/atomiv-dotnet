using Optivem.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Test.Common.WebAutomation
{
    public class TestRadioGroup<T> : IRadioGroup<T>
    {
        private readonly IRadioGroup<T> _radioGroup;

        public TestRadioGroup(IRadioGroup<T> radioGroup)
        {
            _radioGroup = radioGroup;
        }

        public int Count => _radioGroup.Count;

        public bool HasSelected()
        {
            return _radioGroup.HasSelected();
        }

        public T ReadSelected()
        {
            return _radioGroup.ReadSelected();
        }

        public T ReadValue(int index)
        {
            return _radioGroup.ReadValue(index);
        }

        public void Select(T key)
        {
            _radioGroup.Select(key);
        }
    }
}
