using FluentAssertions;
using Optivem.Framework.Core.Common.WebAutomation;
using Optivem.Framework.Core.Common.WebAutomation.Assertion;

namespace Optivem.Framework.Test.Common.WebAutomation
{
    public class TestTextBox<TTextBox> : TestElement<TTextBox>, IAssertableTextBox
        where TTextBox : ITextBox
    {
        public TestTextBox(TTextBox element)
            : base(element)
        {
        }

        public string ReadText()
        {
            return Element.ReadText();
        }

        public void EnterText(string text)
        {
            Element.EnterText(text);
        }

        public void TextShouldBe(string expectedText)
        {
            var actualText = ReadText();
            actualText.Should().Be(expectedText);
        }
    }
}
