using Optivem.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Test.Common.WebAutomation
{
    public interface ITestTextBox : ITextBox
    {
        void TextShouldBe(string expectedText);
    }
}
