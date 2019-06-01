namespace Optivem.Core.Common.WebAutomation
{
    public interface IComboBox<T> : IElement
    {
        void Select(T key);

        T GetSelected();

        bool HasSelected();

        int Count { get; }

        T GetValue(int index);
    }
}