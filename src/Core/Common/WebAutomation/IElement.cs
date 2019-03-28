using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Core.Common.WebAutomation
{
    public interface IElement
    {
        bool Enabled { get; }

        bool Visible { get; }
    }
}
