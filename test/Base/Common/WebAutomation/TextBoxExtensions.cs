using FluentAssertions;
using Optivem.Framework.Core.Common.WebAutomation;

namespace Optivem.Framework.Test.Common.WebAutomation
{
    public static class TextBoxExtensions
    {
        public static void TextShouldBe(this ITextBox textBox, string expectedText)
        {
            var actualText = textBox.ReadText();
            actualText.Should().Be(expectedText);
        }
    }
}
