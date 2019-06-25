using System.Collections.Generic;

namespace Optivem.Core.Application
{
    public interface ICollectionResponseMapper<T, TResponse> : IResponseMapper<IEnumerable<T>, TResponse>
        where TResponse : ICollectionResponse
    {
    }

    public interface ICollectionResponseMapper<T, TResponse, TRecordResponse> : IResponseMapper<IEnumerable<T>, TResponse>
        where TResponse : ICollectionResponse<TRecordResponse>
        where TRecordResponse : IResponse
    {
    }
}
