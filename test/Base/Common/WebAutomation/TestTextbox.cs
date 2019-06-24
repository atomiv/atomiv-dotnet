using FluentAssertions;
using Optivem.Core.Common.WebAutomation;

namespace Optivem.Test.Common.WebAutomation
{
    public class TestTextBox : ITextBox
    {
        private readonly ITextBox _textBox;

        public TestTextBox(ITextBox textBox)
        {
            _textBox = textBox;
        }

        public bool Enabled => _textBox.Enabled;

        public bool Visible => _textBox.Visible;

        public string ReadText()
        {
            return _textBox.ReadText();
        }

        public void EnterText(string text)
        {
            _textBox.EnterText(text);
        }

        public void TextShouldBe(string expectedText)
        {
            var actualText = ReadText();
            actualText.Should().Be(expectedText);
        }
    }
}
