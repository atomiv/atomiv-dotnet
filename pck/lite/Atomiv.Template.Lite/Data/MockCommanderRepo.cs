using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    // click on IComamnderRep, Ctrl + . > Implement interface
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAppCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle & Pan"},
                new Command{Id=0, HowTo="Cut bread", Line="Get a knife", Platform="Knife & chopping board"},
                new Command{Id=0, HowTo="Make cup of tea", Line="Place teabag in cup", Platform="Kettle & Cup"}
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id=0, HowTo="Boil an egg", Line="Boli water", Platform="Kettle & Pan"};
        }
    }
}