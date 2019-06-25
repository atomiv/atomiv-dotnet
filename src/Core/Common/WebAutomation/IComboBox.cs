namespace Optivem.Framework.Core.Common.WebAutomation
{
    public interface IComboBox : IElement
    {
        void SelectByValue(string key);

        void SelectByText(string text);

        string ReadSelectedValue();

        bool HasSelected();

        int Count { get; }

        string ReadValue(int index);
    }

    // TODO: VC: DELETE

    /*

    public interface IComboBox<T> : IComboBox
    {
        void Select(T key);

        T ReadSelected();

        T Read(int index);
    }

    */
}