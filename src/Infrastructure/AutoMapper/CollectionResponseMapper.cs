using AutoMapper;
using Optivem.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

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
