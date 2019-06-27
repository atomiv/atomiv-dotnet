using FluentAssertions;
using Optivem.Framework.Core.Common.WebAutomation;
using Optivem.Framework.Core.Common.WebAutomation.Assertion;

namespace Optivem.Framework.Test.Common.WebAutomation
{
    public class TestRadioButtonGroup<TRadioButtonGroup> : TestElement<TRadioButtonGroup>, IAssertableRadioButtonGroup
        where TRadioButtonGroup : IRadioButtonGroup
    {
        public TestRadioButtonGroup(TRadioButtonGroup element)
            : base(element)
        {
        }

        public int Count => Element.Count;

        public void SelectValue(string key)
        {
            Element.SelectValue(key);
        }

        public string ReadSelectedValue()
        {
            return Element.ReadSelectedValue();
        }

        public string ReadValue(int index)
        {
            return Element.ReadValue(index);
        }

        public bool HasSelected()
        {
            return Element.HasSelected();
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

    // TODO: VC: DELETE
/*

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

    */

}
