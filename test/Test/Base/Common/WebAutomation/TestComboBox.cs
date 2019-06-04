using Optivem.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Test.Common.WebAutomation
{
    public class TestComboBox<T> : IComboBox<T>
    {
        private readonly IComboBox<T> _comboBox;

        public TestComboBox(IComboBox<T> comboBox)
        {
            _comboBox = comboBox;
        }

        public int Count => _comboBox.Count;

        public bool Enabled => _comboBox.Enabled;

        public bool Visible => _comboBox.Visible;

        public T ReadSelected()
        {
            return _comboBox.ReadSelected();
        }

        public T ReadValue(int index)
        {
            return _comboBox.ReadValue(index);
        }

        public bool HasSelected()
        {
            return _comboBox.HasSelected();
        }

        public void Select(T key)
        {
            _comboBox.Select(key);
        }
    }
}
