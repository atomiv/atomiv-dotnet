namespace Optivem.Core.Application.Responses
{
    public interface IDeleteResponse : IResponse
    {
        bool Deleted { get; set; }
    }
}
