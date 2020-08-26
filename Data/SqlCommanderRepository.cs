using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data {
  public class SqlCommanderRepository : ICommanderRepository {
    private readonly CommanderContext Context;

    public SqlCommanderRepository (CommanderContext context) {
      this.Context = context;
    }

    public IEnumerable<Command> GetAllCommands()
    {
      return Context.Commands.ToList();
    }

    public Command GetCommandById(int id)
    {
      return Context.Commands.FirstOrDefault(p=>p.Id==id);
    }
  }
}
