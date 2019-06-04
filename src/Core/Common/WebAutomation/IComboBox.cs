namespace Optivem.Core.Common.WebAutomation
{
    public interface IComboBox : IElement
    {
        void SelectValue(string key);

        string ReadSelectedValue();

        bool HasSelected();

        int Count { get; }

        string ReadValue(int index);
    }

    public interface IComboBox<T> : IComboBox
    {
        void Select(T key);

        T ReadSelected();

        T Read(int index);
    }
}