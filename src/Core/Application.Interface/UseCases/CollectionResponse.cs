using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Core.Application
{
    public abstract class CollectionResponse<TRecordResponse> : Response, ICollectionResponse<TRecordResponse>
        where TRecordResponse : IResponse
    {
        public List<TRecordResponse> Records { get; set; }

        public int Count { get; set; }
    }

    public abstract class CollectionResponse<TRecordResponse, TId> : CollectionResponse<TRecordResponse>
        where TRecordResponse : IResponse<TId>
    {

    }
}
