namespace Optivem.Core.Application
{
    public interface IDeleteResponse : IResponse
    {
        bool Deleted { get; set; }
    }
}