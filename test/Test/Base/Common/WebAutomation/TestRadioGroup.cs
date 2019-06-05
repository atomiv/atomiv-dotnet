using FluentAssertions;
using Optivem.Core.Common.WebAutomation;

namespace Optivem.Test.Common.WebAutomation
{
    public class TestRadioGroup : IRadioGroup
    {
        private readonly IRadioGroup _radioGroup;

        public TestRadioGroup(IRadioGroup radioGroup)
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

    public class TestRadioGroup<T> : TestRadioGroup, IRadioGroup<T>
    {
        private readonly IRadioGroup<T> _radioGroup;

        public TestRadioGroup(IRadioGroup<T> radioGroup)
            : base(radioGroup)
        {
            _radioGroup = radioGroup;
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

        public void ShouldHaveSelection(T key)
        {
            var selected = ReadSelected();
            selected.Should().Be(key);
        }
    }
}
