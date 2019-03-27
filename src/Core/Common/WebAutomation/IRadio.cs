using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Core.Common.WebAutomation
{
    public interface IRadio
    {
        void Select();

        bool Selected { get; }
    }
}
