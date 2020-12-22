// namespace Atomiv.Template.Lite.Data
using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {

        }

        // represent our command objects down to our database as a DbSet
        // and it'll be called commands
        // map here all classes you weant to go to the database
        public DbSet<Command> Commands { get; set; }
    }
}