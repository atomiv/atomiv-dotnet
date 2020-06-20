namespace Atomiv.Core.Common.WebAutomation
{
    public interface IQuery
    {
        FindType FindType { get; }

        string FindBy { get; }
    }
}