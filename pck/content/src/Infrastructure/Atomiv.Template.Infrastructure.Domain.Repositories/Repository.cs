using Atomiv.Infrastructure.EntityFrameworkCore;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;

namespace Atomiv.Template.Infrastructure.Domain.Repositories
{
    public class Repository : Repository<DatabaseContext>
    {
        public Repository(DatabaseContext context) : base(context)
        {
        }
    }
}
