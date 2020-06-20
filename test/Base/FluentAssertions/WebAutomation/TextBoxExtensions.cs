using FluentAssertions;
using Atomiv.Core.Common.WebAutomation;

namespace Atomiv.Test.FluentAssertions.WebAutomation
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