using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Core.Common.WebAutomation
{
    public interface IPage
    {
        ITextBox GetTextBox(FindType findType, string findBy);

        ICheckBox GetCheckBox(FindType findType, string findBy);
    }
}
