namespace Optivem.Infrastructure.AutoMapper
{
    // TODO: VC: DELETE

    /*
    public class BaseResponseMapper<T, TResponse> : Profile, IResponseMapper<T, TResponse>
        where TResponse : IResponse
    {
        public BaseResponseMapper(IMapper mapper)
        {
            Mapper = mapper;

            var map = CreateMap<T, TResponse>();
            Extend(map);
        }

        protected IMapper Mapper { get; private set; }

        public TResponse Map(T obj)
        {
            return Mapper.Map<T, TResponse>(obj);
        }

        protected virtual void Extend(IMappingExpression<T, TResponse> map)
        {
            // NOTE: No default implementation
        }
    }

    */
}
