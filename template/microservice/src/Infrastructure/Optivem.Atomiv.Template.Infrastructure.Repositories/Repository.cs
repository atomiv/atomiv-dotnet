using Optivem.Atomiv.Infrastructure.EntityFrameworkCore;
using Optivem.Atomiv.Template.Infrastructure.Persistence.Common;

namespace Optivem.Atomiv.Template.Infrastructure.Repositories
{
    public class Repository : Repository<DatabaseContext>
    {
        public Repository(DatabaseContext context) : base(context)
        {
        }
    }
}
