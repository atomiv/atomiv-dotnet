using System.Collections.Generic;

namespace Optivem.Core.Application
{
    public interface IListResponse : IResponse
    {
    }

    public interface IListResponse<TElement, TElementId> : IListResponse, IResponse
        where TElement : IListElementResponse<TElementId>
    {
        List<TElement> Data { get; set; }
    }

    public interface IListElementResponse : IResponse
    {
    }

    public interface IListElementResponse<TId> : IListElementResponse, IResponse<TId>
    {
    }
}