using FluentAssertions;
using Optivem.Atomiv.Core.Common.WebAutomation;
using System.Linq;

namespace Optivem.Atomiv.Test.FluentAssertions.WebAutomation
{
    public static class CheckBoxGroupExtensions
    {
        public static void ShouldNotHaveSelection(this ICheckBoxGroup checkBoxGroup)
        {
            checkBoxGroup.HasSelected().Should().BeFalse();
        }

        public static void ShouldHaveSelectedValue(this ICheckBoxGroup checkBoxGroup, string expected)
        {
            var actual = checkBoxGroup.ReadSelectedValues();
            actual.Should().Contain(expected);
        }

        public static void ShouldHaveSelectionCount(this ICheckBoxGroup checkBoxGroup, int expected)
        {
            var actual = checkBoxGroup.ReadSelectedValues();
            actual.Count.Should().Be(expected);
        }

        public static void ShouldHaveOneSelectedItem(this ICheckBoxGroup checkBoxGroup)
        {
            var actual = checkBoxGroup.ReadSelectedValues();
            actual.Count.Should().Be(1);
        }

        public static void ShouldHaveOneSelectedValue(this ICheckBoxGroup checkBoxGroup, string expected)
        {
            var actualCount = checkBoxGroup.ReadSelectedValues();
            actualCount.Count.Should().Be(1);
            var actualValue = actualCount.Single();
            actualValue.Should().Be(expected);
        }
    }
}