using System;
using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IProcessOneRequest> commands;
      IProcessOneRequest unknownRequestProcessor;

    public CommandRegistry(IEnumerable<IProcessOneRequest> commands, IProcessOneRequest unknownRequestProcessor)
    {
      this.commands = commands;
        this.unknownRequestProcessor = unknownRequestProcessor;
    }

    public IProcessOneRequest get_the_command_that_can_process(IProvideDetailsToCommands request)
    {
        var command = commands.FirstOrDefault( x => x.can_process( request ) );

        return command ?? unknownRequestProcessor; 
    }
  }
}