using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class Repository<TContext> : IRepository
    {
        public Repository(TContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public TContext Context { get; }

        public IMapper Mapper { get; }
    }
}
