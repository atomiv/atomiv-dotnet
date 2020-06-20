namespace Atomiv.Core.Common.WebAutomation
{
    public interface IRadioButton : IElement
    {
        void Select();

        bool IsSelected { get; }

        string Value { get; }
    }
}