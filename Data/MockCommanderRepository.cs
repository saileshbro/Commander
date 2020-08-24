using System.Collections.Generic;
using Commander.Models;
namespace Commander.Data {
  public class MockCommanderRepository : ICommanderRepository
  {
    public IEnumerable<Command> GetAllCommands()
    {
        return new List<Command>{
          new Command{Id=0,HowTo="Boil an egg",Line="Boil water",Platform="Kettle"},
          new Command{Id=1,HowTo="Boil Milk",Line="Boil Add sugar",Platform="Kettle"},
          };
    }

    public Command GetCommandById(int id)
    {
      return new Command{Id=0,HowTo="Boil an egg",Line="Boil water",Platform="Kettle"};
    }
  }
}
