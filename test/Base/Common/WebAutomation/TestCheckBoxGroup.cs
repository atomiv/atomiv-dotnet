using FluentAssertions;
using Optivem.Framework.Core.Common.WebAutomation;
using Optivem.Framework.Core.Common.WebAutomation.Assertion;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Framework.Test.Common.WebAutomation
{
    public class TestCheckBoxGroup<TCheckBoxGroup> : TestElement<TCheckBoxGroup>, IAssertableCheckBoxGroup
        where TCheckBoxGroup : ICheckBoxGroup
    {
        public TestCheckBoxGroup(TCheckBoxGroup element)
            : base(element)
        {
        }

        public int Count => Element.Count;

        public void SelectValue(string key)
        {
            Element.SelectValue(key);
        }

        public void DeselectValue(string key)
        {
            Element.DeselectValue(key);
        }

        public List<string> ReadSelectedValues()
        {
            return Element.ReadSelectedValues();
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

        public void ShouldHaveSelectedValue(string expected)
        {
            var actual = ReadSelectedValues();
            actual.Should().Contain(expected);
        }

        public void ShouldHaveSelectionCount(int expected)
        {
            var actual = ReadSelectedValues();
            actual.Count.Should().Be(expected);
        }

        public void ShouldHaveOneSelectedItem()
        {
            var actual = ReadSelectedValues();
            actual.Count.Should().Be(1);
        }

        public void ShouldHaveOneSelectedValue(string expected)
        {
            var actualCount = ReadSelectedValues();
            actualCount.Count.Should().Be(1);
            var actualValue = actualCount.Single();
            actualValue.Should().Be(expected);
        }

        public void ShouldHaveSelection()
        {
            throw new System.NotImplementedException();
        }
    }

    // TODO: VC: DELETE

    /*
    public class TestCheckBoxGroup : TestCheckBoxGroup<ICheckBoxGroup>
    {
        public TestCheckBoxGroup(ICheckBoxGroup element) : base(element)
        {
        }
    }

    */

    // TODO: VC: DELETE

    /*

    public class TestCheckBoxGroup<TCheckBoxGroup, T> : TestCheckBoxGroup<TCheckBoxGroup>, ICheckBoxGroup<T>
        where TCheckBoxGroup : ICheckBoxGroup<T>
    {
        public TestCheckBoxGroup(TCheckBoxGroup element)
            : base(element)
        {
        }

        public void Deselect(T key)
        {
            Element.Deselect(key);
        }

        public List<T> ReadSelected()
        {
            return Element.ReadSelected();
        }

        public T Read(int index)
        {
            return Element.Read(index);
        }

        public void Select(T key)
        {
            Element.Select(key);
        }

        public void ShouldHaveSelection(T key)
        {
            var selected = ReadSelected();
            selected.Should().Contain(key);
        }
    }

    */
}
