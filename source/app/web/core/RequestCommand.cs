namespace app.web.core
{
  public class RequestCommand : IProcessOneRequest
  {
    RequestCriteria request_criteria;

    public RequestCommand(RequestCriteria request_criteria)
    {
      this.request_criteria = request_criteria;
    }

    public void process(IProvideDetailsToCommands request)
    {
      throw new System.NotImplementedException();
    }

    public bool can_process(IProvideDetailsToCommands request)
    {
      return request_criteria(request);
    }
  }
}