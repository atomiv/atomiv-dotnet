using AutoMapper;
using Optivem.Framework.Core.Application;
using System.Collections.Generic;

namespace Optivem.Framework.Infrastructure.AutoMapper
{
    public class CollectionResponseMapper<T, TResponse> : ResponseMapper<IEnumerable<T>, TResponse>, ICollectionResponseMapper<T, TResponse>
        where TResponse : ICollectionResponse
    {
        public CollectionResponseMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}
