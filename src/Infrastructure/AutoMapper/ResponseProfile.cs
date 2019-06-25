using AutoMapper;
using Optivem.Framework.Core.Application;

namespace Optivem.Framework.Infrastructure.AutoMapper
{
    public abstract class ResponseProfile<T, TResponse> : Profile
        where TResponse : IResponse
    {
        public ResponseProfile()
        {
            var map = CreateMap<T, TResponse>();
            Extend(map);
        }

        protected virtual void Extend(IMappingExpression<T, TResponse> map)
        {
            // NOTE: No default implementation
        }
    }
}