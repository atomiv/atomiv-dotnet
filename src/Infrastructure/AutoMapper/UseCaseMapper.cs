
using AutoMapper;
using Optivem.Framework.Core.Application.Mappers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Infrastructure.AutoMapper
{
    public class UseCaseMapper : IUseCaseMapper
    {
        public UseCaseMapper(IMapper mapper)
        {
            Mapper = mapper;
        }

        protected IMapper Mapper { get; private set; }

        public U Map<T, U>(T source)
        {
            return Mapper.Map<T, U>(source);
        }
    }
}
