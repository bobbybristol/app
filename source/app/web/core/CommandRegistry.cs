using System.Collections.Generic;
using System.Linq;
using app.utility;
using app.web.core.stubs;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessOneRequest> commands;
    IProcessOneRequest special_case;

    public CommandRegistry(IEnumerable<IProcessOneRequest> commands, IProcessOneRequest special_case)
    {
      this.commands = commands;
      this.special_case = special_case;
    }

    public CommandRegistry():this(Stub.with<StubSetOfCommands>(),
      Stub.with<StubMissingCommand>())
    {
    }

    public IProcessOneRequest get_the_command_that_can_process(IProvideDetailsToCommands request)
    {
      return commands.FirstOrDefault(x => x.can_process(request)) ?? special_case;
    }
  }
}