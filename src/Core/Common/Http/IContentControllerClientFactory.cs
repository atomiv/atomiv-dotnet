namespace Optivem.Framework.Core.Common.Http
{
    public interface IContentControllerClientFactory
    {
        IContentControllerClient Create(string controllerUri);
    }
}