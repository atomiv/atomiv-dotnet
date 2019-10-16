using Optivem.Framework.Core.Common;

namespace Optivem.Framework.Core.Domain
{
    public class ExistsAggregateRootResponse : IResponse
    {
        public ExistsAggregateRootResponse(bool exists)
        {
            Exists = exists;
        }

        public bool Exists { get; }
    }
}