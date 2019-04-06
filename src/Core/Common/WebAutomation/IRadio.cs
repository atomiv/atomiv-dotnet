namespace Optivem.Platform.Core.Common.WebAutomation
{
    public interface IRadio : IElement
    {
        void Select();

        bool Selected { get; }
    }
}
