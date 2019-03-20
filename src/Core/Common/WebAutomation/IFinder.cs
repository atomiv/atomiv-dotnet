using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Core.Common.WebAutomation
{
    public interface IFinder
    {
        ITextBox FindTextBoxByName(string name);
    }
}
