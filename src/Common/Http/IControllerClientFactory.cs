namespace Optivem.Common.Http
{
    public interface IControllerClientFactory
    {
        IControllerClient Create(string controllerUri);
    }
}