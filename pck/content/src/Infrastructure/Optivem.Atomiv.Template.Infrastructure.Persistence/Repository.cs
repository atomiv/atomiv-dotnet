using Optivem.Atomiv.Infrastructure.EntityFrameworkCore;

namespace Optivem.Atomiv.Template.Infrastructure.Persistence
{
    public class Repository : Repository<DatabaseContext>
    {
        public Repository(DatabaseContext context) : base(context)
        {
        }
    }
}
