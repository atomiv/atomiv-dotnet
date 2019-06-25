namespace Optivem.Framework.Core.Common.WebAutomation
{
    public interface IRadioButton : IElement
    {
        void Select();

        bool IsSelected { get; }
    }
}