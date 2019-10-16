using System.Collections.Generic;

namespace Optivem.Framework.Core.Common
{
    public interface ICollectionResponse<TRecordResponse> : IResponse
    {
        List<TRecordResponse> Records { get; set; }

        int TotalRecords { get; set; }
    }

    public interface ICollectionResponse<TRecordResponse, TId> : ICollectionResponse<TRecordResponse>
    {

    }
}
