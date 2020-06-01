using Optivem.Atomiv.Infrastructure.EntityFrameworkCore;
using Optivem.Atomiv.Template.Infrastructure.Domain.Persistence.Common;

namespace Optivem.Atomiv.Template.Infrastructure.Domain.Repositories
{
    public class Repository : Repository<DatabaseContext>
    {
        public Repository(DatabaseContext context) : base(context)
        {
        }
    }
}
