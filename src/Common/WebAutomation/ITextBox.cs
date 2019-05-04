namespace Optivem.Common.WebAutomation
{
    public interface ITextBox : IElement
    {
        void SetText(string text);

        string GetText();
    }
}
