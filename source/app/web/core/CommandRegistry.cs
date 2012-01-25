using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessOneRequest> commands;

    public CommandRegistry(IEnumerable<IProcessOneRequest> commands)
    {
      this.commands = commands;
    }

    public IProcessOneRequest get_the_command_that_can_process(IProvideDetailsToCommands request)
    {
      return commands.First(x => x.can_process(request));
    }
  }
}