using System;
using System.Collections.Generic;

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
        foreach ( var command in commands )
        {
            if (command.can_process(request))
                return command;
        }

        throw new ArgumentException("I don't have a command that can process that request.");
    }
  }
}