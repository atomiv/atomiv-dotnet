using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Core.Application.Responses
{
    public interface IFindAllRecordResponse : IResponse
    {

    }

    public interface IFindAllRecordResponse<TId> : IFindAllRecordResponse, IResponse<TId>
    {
    }
}
