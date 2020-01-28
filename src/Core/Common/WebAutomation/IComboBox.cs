namespace Optivem.Atomiv.Core.Common.WebAutomation
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
}