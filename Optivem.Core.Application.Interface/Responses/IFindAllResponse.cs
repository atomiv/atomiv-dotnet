using System.Collections.Generic;

namespace Optivem.Core.Application
{
    public interface IFindAllResponse : IResponse
    {

    }

    public interface IFindAllResponse<T> : IFindAllResponse, IResponse
    {
        List<T> Data { get; set; }
    }
}
