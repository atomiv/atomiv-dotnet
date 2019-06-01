using System.Collections.Generic;

namespace Optivem.Core.Application
{
    public interface ICollectionResponse : IResponse
    {

    }

    public interface ICollectionResponse<TResponse> : ICollectionResponse
        where TResponse : IResponse
    {
        List<TResponse> Data { get; set; }
    }

    public interface ICollectionResponse<TResponse, TId> : ICollectionResponse<TResponse>
        where TResponse : IResponse<TId>
    {

    }

    // TODO: VC: DELETE

    /*
     * 
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
     * 
     * 
     */

}
