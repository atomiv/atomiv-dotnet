namespace Optivem.Framework.Core.Common.WebAutomation
{
    public interface ITextBox : IElement
    {
        void EnterText(string text);

        string ReadText();
    }
}