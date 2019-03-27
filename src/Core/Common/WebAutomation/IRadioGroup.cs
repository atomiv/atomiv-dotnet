using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Platform.Core.Common.WebAutomation
{
    public interface IRadioGroup<T>
    {
        void Select(T key);

        T GetSelected();

        bool HasSelected();

        int Count { get; }

        T GetValue(int index);
    }
}
