using AutoMapper;
using Optivem.Core.Application;
using System.Collections.Generic;

namespace Optivem.Infrastructure.AutoMapper
{
    public class CollectionResponseMapper<T, TResponse> : ResponseMapper<IEnumerable<T>, TResponse>, ICollectionResponseMapper<T, TResponse>
        where TResponse : ICollectionResponse
    {
        public CollectionResponseMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}
