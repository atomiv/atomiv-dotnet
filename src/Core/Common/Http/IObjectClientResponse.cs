namespace Optivem.Atomiv.Core.Common.Http
{
    public interface IObjectClientResponse : IClientResponse
    {
        IProblemDetails ProblemDetails { get; }
    }

    public interface IObjectClientResponse<T> : IObjectClientResponse
    {
        T Data { get; }
    }
}