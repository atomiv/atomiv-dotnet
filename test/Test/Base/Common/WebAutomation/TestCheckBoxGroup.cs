using FluentAssertions;
using Optivem.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Optivem.Test.Common.WebAutomation
{
    public class TestCheckBoxGroup : ICheckBoxGroup
    {
        private readonly ICheckBoxGroup _checkBoxGroup;

        public TestCheckBoxGroup(ICheckBoxGroup checkBoxGroup)
        {
            _checkBoxGroup = checkBoxGroup;
        }

        public int Count => _checkBoxGroup.Count;

        public void SelectValue(string key)
        {
            _checkBoxGroup.SelectValue(key);
        }

        public void DeselectValue(string key)
        {
            _checkBoxGroup.DeselectValue(key);
        }

        public List<string> ReadSelectedValues()
        {
            return _checkBoxGroup.ReadSelectedValues();
        }

        public string ReadValue(int index)
        {
            return _checkBoxGroup.ReadValue(index);
        }

        public bool HasSelected()
        {
            return _checkBoxGroup.HasSelected();
        }

        public void ShouldNotHaveSelection()
        {
            HasSelected().Should().BeFalse();
        }

        public void ShouldHaveSelectedValue(string key)
        {
            var selected = ReadSelectedValues();
            selected.Should().Contain(key);
        }

        public void ShouldHaveSelectionCount(int expectedCount)
        {
            var selected = ReadSelectedValues();
            selected.Count.Should().Be(expectedCount);
        }

        public void ShouldHaveOneSelectedItem()
        {
            var selected = ReadSelectedValues();
            selected.Count.Should().Be(1);
        }

        public void ShouldHaveOneSelectedValue(string key)
        {
            var selected = ReadSelectedValues();
            selected.Count.Should().Be(1);
            var selectedValue = selected.Single();
            selectedValue.Should().Be(key);
        }
    }

    public class TestCheckBoxGroup<T> : TestCheckBoxGroup, ICheckBoxGroup<T>
    {
        private readonly ICheckBoxGroup<T> _checkBoxGroup;

        public TestCheckBoxGroup(ICheckBoxGroup<T> checkBoxGroup)
            : base(checkBoxGroup)
        {
            _checkBoxGroup = checkBoxGroup;
        }

        public void Deselect(T key)
        {
            _checkBoxGroup.Deselect(key);
        }

        public List<T> ReadSelected()
        {
            return _checkBoxGroup.ReadSelected();
        }

        public T Read(int index)
        {
            return _checkBoxGroup.Read(index);
        }

        public void Select(T key)
        {
            _checkBoxGroup.Select(key);
        }

        public void ShouldHaveSelection(T key)
        {
            var selected = ReadSelected();
            selected.Should().Contain(key);
        }
    }
}
