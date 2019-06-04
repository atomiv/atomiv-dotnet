namespace Optivem.Core.Common.WebAutomation
{
    public interface IComboBox<T> : IElement
    {
        void Select(T key);

        T ReadSelected();

        bool HasSelected();

        int Count { get; }

        T ReadValue(int index);
    }
}