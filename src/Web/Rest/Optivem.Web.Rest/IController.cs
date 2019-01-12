using System;
using System.Threading.Tasks;

namespace Optivem.Commons.RestService
{
    public interface IController<TRequest, 
        TGetResourcesResponse, 
        TGetResourceResponse,
        TPutResourceResponse,
        TPostResourceResponse, 
        TDeleteResourceResponse, 
        TKey>
    {
        TGetResourcesResponse GetResources();

        TGetResourceResponse GetResource(TKey id);

        TPutResourceResponse PutResource(TKey id, TRequest request);

        TPostResourceResponse PostResource(TRequest request);

        TDeleteResourceResponse DeleteResource(TKey id);
    }
}
