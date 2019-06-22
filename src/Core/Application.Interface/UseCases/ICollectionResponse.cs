using System.Collections.Generic;

namespace Optivem.Core.Application
{
    public interface ICollectionResponse : IResponse
    {

    }

    public interface ICollectionResponse<TRecordResponse> : ICollectionResponse
        where TRecordResponse : IResponse
    {
        List<TRecordResponse> Records { get; set; }

        int Count { get; set; }
    }

    public interface ICollectionResponse<TRecordResponse, TId> : ICollectionResponse<TRecordResponse>
        where TRecordResponse : IResponse<TId>
    {

    }
}
