namespace Optivem.Framework.Core.Common.WebAutomation
{
    public interface IRadioGroup<T>
    {
        void Select(T key);

        T GetSelected();

        bool HasSelected();

        int Count { get; }

        T GetValue(int index);
    }
}
