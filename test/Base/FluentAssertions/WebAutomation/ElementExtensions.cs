using FluentAssertions;
using Optivem.Atomiv.Core.Common.WebAutomation;

namespace Optivem.Atomiv.Test.FluentAssertions.WebAutomation
{
    public static class ElementExtensions
    {
        public static void ShouldBeEnabled(this IElement element)
        {
            element.Enabled.Should().Be(true);
        }

        public static void ShouldBeDisabled(this IElement element)
        {
            element.Enabled.Should().Be(false);
        }

        public static void ShouldBeVisible(this IElement element)
        {
            element.Visible.Should().Be(true);
        }

        public static void ShouldBeHidden(this IElement element)
        {
            element.Visible.Should().Be(false);
        }
    }
}