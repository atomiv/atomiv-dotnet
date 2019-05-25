namespace Optivem.Common.Http
{
    public interface IObjectClientResponse<T> : IClientResponse
    {
        T Content { get; }

        IProblemDetails ProblemDetails { get; }
    }
}
