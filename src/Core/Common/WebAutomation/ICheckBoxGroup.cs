using System.Collections.Generic;

namespace Optivem.Core.Common.WebAutomation
{
    public interface ICheckBoxGroup<T>
    {
        void Select(T key);

        void Deselect(T key);

        List<T> ReadSelected();

        bool HasSelected();

        int Count { get; }

        T ReadValue(int index);
    }
}