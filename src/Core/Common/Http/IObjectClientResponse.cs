namespace Optivem.Core.Common.Http
{
    public interface IObjectClientResponse<T> : IClientResponse
    {
        T Data { get; }

        IProblemDetails ProblemDetails { get; }
    }
}
