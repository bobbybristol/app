namespace app.web.core
{
  public class FrontController : IProcessRequests
  {
      IFindCommands commandFinder;

      public FrontController(IFindCommands commandFinder)
      {
          this.commandFinder = commandFinder;
      }

    public void process(IProvideDetailsToCommands request)
    {
        var result = commandFinder.get_the_command_that_can_process( request );
        result.process(request);
    }
  }
}