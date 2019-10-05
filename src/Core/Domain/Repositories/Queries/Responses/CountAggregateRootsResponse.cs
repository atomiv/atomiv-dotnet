using Optivem.Framework.Core.Common;

namespace Optivem.Framework.Core.Domain
{
    public class CountAggregateRootsResponse : IResponse
    {
        public CountAggregateRootsResponse(long count)
        {
            Count = count;
        }

        public long Count { get; }
    }
}
