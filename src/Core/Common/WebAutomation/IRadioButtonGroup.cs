namespace Optivem.Framework.Core.Common.WebAutomation
{
    public interface IRadioButtonGroup
    {
        void SelectValue(string key);

        string ReadSelectedValue();

        bool HasSelected();

        int Count { get; }

        string ReadValue(int index);
    }
}