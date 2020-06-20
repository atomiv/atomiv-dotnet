using System.Collections.Generic;

namespace Atomiv.Core.Common.WebAutomation
{
    public interface ICheckBoxGroup
    {
        void EnsureValueSelected(string key);

        void EnsureValueDeselected(string key);

        List<string> ReadSelectedValues();

        bool HasSelected();

        int Count { get; }

        string ReadValue(int index);
    }
}