namespace Atomiv.Core.Common.WebAutomation
{
    public interface ITextBox : IElement
    {
        void InputText(string text);

        string ReadText();
    }
}