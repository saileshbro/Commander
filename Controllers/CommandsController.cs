using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;
namespace Commander.Controllers
{
  [Route("api/commands")]
  [ApiController]
  public class CommandsController : ControllerBase
  {
    private readonly ICommanderRepository repository;
    private readonly IMapper mapper;
    public CommandsController(ICommanderRepository repository,IMapper mapper)
    {
      this.repository = repository;
      this.mapper= mapper;
    }

    // GET api/commands
    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetallCommands()
    {
      return Ok(mapper.Map<IEnumerable<CommandReadDto>>(repository.GetAllCommands()));

    }
    // GET api/commands/{id}
    [HttpGet("{id}")]
    public ActionResult<CommandReadDto> GetCommandById(int id){
      var commandItem =repository.GetCommandById(id);
      if(commandItem!=null){
        return Ok(mapper.Map<CommandReadDto>(commandItem));
      }
      return NotFound();
    }
  }
}
