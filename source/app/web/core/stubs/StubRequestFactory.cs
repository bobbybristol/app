using System.Web;

namespace app.web.core.stubs
{
  public class StubRequestFactory : ICreateControllerRequests
  {
    public IProvideDetailsToCommands create_controller_request(HttpContext current_request)
    {
      return new StubRequest();
    }

    class StubRequest : IProvideDetailsToCommands
    {
    }
  }
}