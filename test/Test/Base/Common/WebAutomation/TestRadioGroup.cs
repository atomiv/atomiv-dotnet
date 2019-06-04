using FluentAssertions;
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

        public void SelectValue(string key)
        {
            _radioGroup.SelectValue(key);
        }

        public string ReadSelectedValue()
        {
            return _radioGroup.ReadSelectedValue();
        }

        public string ReadValue(int index)
        {
            return _radioGroup.ReadValue(index);
        }

        public bool HasSelected()
        {
            return _radioGroup.HasSelected();
        }

        public T ReadSelected()
        {
            return _radioGroup.ReadSelected();
        }

        public T Read(int index)
        {
            return _radioGroup.Read(index);
        }

        public void Select(T key)
        {
            _radioGroup.Select(key);
        }

        public void ShouldNotHaveSelection()
        {
            HasSelected().Should().BeFalse();
        }

        public void ShouldHaveSelection(T key)
        {
            var selected = ReadSelected();
            selected.Should().Be(key);
        }


    }
}
