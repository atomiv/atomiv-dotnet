using System.Collections.Generic;

namespace Optivem.Framework.Core.Common
{
    public abstract class CollectionResponse<TRecordResponse> : Response, ICollectionResponse<TRecordResponse>
        where TRecordResponse : IResponse
    {
        public List<TRecordResponse> Records { get; set; }

        public int TotalRecords { get; set; }
    }

    public abstract class CollectionResponse<TRecordResponse, TId> : CollectionResponse<TRecordResponse>
        where TRecordResponse : IResponse<TId>
    {

    }
}
