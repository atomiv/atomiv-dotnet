namespace Optivem.Core.Common.WebAutomation
{
    public interface IRadioGroup
    {
        void SelectValue(string key);

        string ReadSelectedValue();

        bool HasSelected();

        int Count { get; }

        string ReadValue(int index);
    }

    public interface IRadioGroup<T> : IRadioGroup
    {
        void Select(T key);

        T ReadSelected();

        T Read(int index);
    }


}