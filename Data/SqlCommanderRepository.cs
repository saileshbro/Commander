using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
  public class SqlCommanderRepository : ICommanderRepository
  {
    private readonly CommanderContext Context;

    public SqlCommanderRepository(CommanderContext context)
    {
      this.Context = context;
    }

    public void CreateCommand(Command command)
    {
      if (command == null)
      {
        throw new ArgumentNullException(nameof(command));
      }
      Context.Add(command);
    }

    public void DeleteCommand(Command command)
    {
      if (command == null)
      {
        throw new ArgumentNullException(nameof(command));
      }
      Context.Commands.Remove(command);
    }

    public IEnumerable<Command> GetAllCommands()
    {
      return Context.Commands.ToList();
    }

    public Command GetCommandById(int id)
    {
      return Context.Commands.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
      return Context.SaveChanges() > 0;
    }

    public void UpdateCommand(Command command)
    {
      //
      return;
    }
  }
}
