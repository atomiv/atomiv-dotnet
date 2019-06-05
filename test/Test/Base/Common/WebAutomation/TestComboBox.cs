using FluentAssertions;
using Optivem.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Test.Common.WebAutomation
{
    public class TestComboBox : IComboBox
    {
        private readonly IComboBox _comboBox;

        public TestComboBox(IComboBox comboBox)
        {
            _comboBox = comboBox;
        }

        public int Count => _comboBox.Count;

        public bool Enabled => _comboBox.Enabled;

        public bool Visible => _comboBox.Visible;

        public void SelectValue(string key)
        {
            _comboBox.SelectValue(key);
        }

        public string ReadSelectedValue()
        {
            return _comboBox.ReadSelectedValue();
        }

        public string ReadValue(int index)
        {
            return _comboBox.ReadValue(index);
        }

        public bool HasSelected()
        {
            return _comboBox.HasSelected();
        }

        public void ShouldNotHaveSelection()
        {
            HasSelected().Should().BeFalse();
        }

        public void ShouldHaveSelectedValue(string key)
        {
            var selected = ReadSelectedValue();
            selected.Should().Be(key);
        }
    }

    public class TestComboBox<T> : TestComboBox, IComboBox<T>
    {
        private readonly IComboBox<T> _comboBox;

        public TestComboBox(IComboBox<T> comboBox)
            : base(comboBox)
        {
            _comboBox = comboBox;
        }

        public T ReadSelected()
        {
            return _comboBox.ReadSelected();
        }

        public T Read(int index)
        {
            return _comboBox.Read(index);
        }

        public void Select(T key)
        {
            _comboBox.Select(key);
        }
    }
}
