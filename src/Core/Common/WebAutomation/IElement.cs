namespace Optivem.Atomiv.Core.Common.WebAutomation
{
    public interface IElement
    {
        bool Enabled { get; }

        bool Visible { get; }

        string Text { get; }

        string GetAttributeValue(string attribute);
    }
}