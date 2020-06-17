using Optivem.Atomiv.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Atomiv.Core.Application
{
    public class BaseApplicationUser<TRequestType> : IApplicationUser<TRequestType>
        where TRequestType : Enum
    {
        public BaseApplicationUser(IEnumerable<TRequestType> requestTypes)
        {
            RequestTypes = requestTypes;
        }

        public IEnumerable<TRequestType> RequestTypes { get; }

        public bool CanExecute(TRequestType requestType)
        {
            return RequestTypes.Any(e => e.Equals(requestType));
        }
    }
}