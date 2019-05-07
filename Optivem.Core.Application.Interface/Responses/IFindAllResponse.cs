using System.Collections.Generic;

namespace Optivem.Core.Application.Responses
{
    public interface IFindAllResponse : IResponse
    {

    }

    public interface IFindAllResponse<T> : IFindAllResponse, IResponse
    {
        List<T> Data { get; set; }
    }
}
