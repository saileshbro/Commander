using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;
namespace Commander.Controllers
{
  [Route("api/commands")]
  [ApiController]
  public class CommandsController : ControllerBase
  {
    private readonly ICommanderRepository repository;
    public CommandsController(ICommanderRepository repository)
    {
       this.repository = repository;
    }

    // GET api/commands
    [HttpGet]
    public ActionResult<IEnumerable<Command>> GetallCommands()
    {
      return Ok(repository.GetAllCommands());

    }
    // GET api/commands/{id}
    [HttpGet("{id}")]
    public ActionResult<Command> GetCommandById(int id){
      return Ok(repository.GetCommandById(id));
    }
  }
}
