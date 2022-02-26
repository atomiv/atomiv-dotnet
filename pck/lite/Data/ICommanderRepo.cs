// Commander instead of Atomiv.Template.Lite
// Command.cs

using System.Collections.Generic;
using Commander.Entities;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAppCommands();
        Command GetCommandById(int id);
    }
}