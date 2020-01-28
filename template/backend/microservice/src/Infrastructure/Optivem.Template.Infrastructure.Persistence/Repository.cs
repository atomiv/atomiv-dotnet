using Optivem.Atomiv.Infrastructure.EntityFrameworkCore;

namespace Optivem.Template.Infrastructure.Persistence
{
    public class Repository : Repository<DatabaseContext>
    {
        public Repository(DatabaseContext context) : base(context)
        {
        }
    }
}
