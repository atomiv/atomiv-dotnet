using FluentAssertions;
using Optivem.Core.Common.WebAutomation;
using Optivem.Infrastructure.Selenium;
using Optivem.Test.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Test.Xunit.Selenium
{
    public class TestTextBox : ITestTextBox
    {
        private readonly ITextBox _textBox;

        public TestTextBox(ITextBox textBox)
        {
            _textBox = textBox;
        }

        public bool Enabled => _textBox.Enabled;

        public bool Visible => _textBox.Visible;

        public string GetText()
        {
            return _textBox.GetText();
        }

        public void SetText(string text)
        {
            _textBox.SetText(text);
        }

        public void TextShouldBe(string expectedText)
        {
            var actualText = GetText();
            actualText.Should().Be(expectedText);
        }
    }
}
