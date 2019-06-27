using FluentAssertions;
using Optivem.Framework.Core.Common.WebAutomation;

namespace Optivem.Framework.Test.FluentAssertions.WebAutomation
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
