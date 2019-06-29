namespace Optivem.Framework.Core.Common.WebAutomation
{
    public interface ICheckBox : IElement
    {
        string Value { get; }

        bool IsSelected { get; }

        void Click();

        void EnsureSelected();

        void EnsureDeselected();
    }
}