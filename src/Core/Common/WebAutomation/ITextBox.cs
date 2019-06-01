namespace Optivem.Core.Common.WebAutomation
{
    public interface ITextBox : IElement
    {
        void SetText(string text);

        string GetText();
    }
}