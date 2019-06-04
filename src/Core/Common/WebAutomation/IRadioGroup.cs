namespace Optivem.Core.Common.WebAutomation
{
    public interface IRadioGroup<T>
    {
        void Select(T key);

        T ReadSelected();

        bool HasSelected();

        int Count { get; }

        T ReadValue(int index);
    }
}