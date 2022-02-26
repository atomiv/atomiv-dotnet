using System.Collections.Generic;
using Commander.Data;
using Commander.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    // TODO: JC: I assume you'll remove this because it's not needed
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;

        public CommandsController(ICommanderRepo repository)
        {
            // ctrl + . - select 2nd option
            _repository = repository;
        }
        
        //not the best way to do it
        // private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        //GET api/commands
        // results will come from our repository
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAppCommands();

            return Ok(commandItems);
        }

        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            return Ok(commandItem);
        }
    }
}

// in Postman
// GET \/ http://localhost:500/api/commands/