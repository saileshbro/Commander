using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
namespace Commander.Controllers
{
  [Route("api/commands")]
  [ApiController]
  public class CommandsController : ControllerBase
  {
    private readonly ICommanderRepository repository;
    private readonly IMapper mapper;
    public CommandsController(ICommanderRepository repository, IMapper mapper)
    {
      this.repository = repository;
      this.mapper = mapper;
    }

    // GET api/commands
    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetallCommands()
    {
      return Ok(mapper.Map<IEnumerable<CommandReadDto>>(repository.GetAllCommands()));

    }
    // GET api/commands/{id}
    [HttpGet("{id}", Name = "GetCommandById")]
    public ActionResult<CommandReadDto> GetCommandById(int id)
    {
      var commandItem = repository.GetCommandById(id);
      if (commandItem != null)
      {
        return Ok(mapper.Map<CommandReadDto>(commandItem));
      }
      return NotFound();
    }

    //POST api/commands
    [HttpPost]
    public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
    {
      Command command = mapper.Map<Command>(commandCreateDto);
      repository.CreateCommand(command);
      repository.SaveChanges();
      CommandReadDto commandReadDto = mapper.Map<CommandReadDto>(command);
      return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
    }
    // PUT api/commands/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
    {
      Command commandModelFromRepo = repository.GetCommandById(id);
      if (commandModelFromRepo == null)
      {
        return NotFound();
      }
      Command command = mapper.Map(commandUpdateDto, commandModelFromRepo);
      repository.UpdateCommand(command);
      repository.SaveChanges();
      return NoContent();
    }

    // PATCH api/commands/{id}
    [HttpPatch("{id}")]
    public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
    {
      Command commandModelFromRepo = repository.GetCommandById(id);
      if (commandModelFromRepo == null)
      {
        return NotFound();
      }
      CommandUpdateDto commandToPatch = mapper.Map<CommandUpdateDto>(commandModelFromRepo);
      patchDoc.ApplyTo(commandToPatch, ModelState);
      if (!TryValidateModel(commandToPatch))
      {
        return ValidationProblem(ModelState);
      }
      mapper.Map(commandToPatch, commandModelFromRepo);
      repository.UpdateCommand(commandModelFromRepo);
      repository.SaveChanges();
      return NoContent();
    }
    // DELETE api/commands/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteCommand(int id)
    {
      Command commandModelFromRepo = repository.GetCommandById(id);
      if (commandModelFromRepo == null)
      {
        return NotFound();
      }
      repository.DeleteCommand(commandModelFromRepo);
      repository.SaveChanges();
      return NoContent();
    }
  }
}
