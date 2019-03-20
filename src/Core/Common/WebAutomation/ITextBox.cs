using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Core.Common.WebAutomation
{
    public interface ITextBox
    {
        void SetText(string text);

        string GetText();
    }
}
