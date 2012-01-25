namespace app.web.core
{
  public class RequestCommand : IProcessOneRequest
  {
    RequestCriteria request_criteria;
    IImplementAFeature implement_Feature;

    public RequestCommand(RequestCriteria request_criteria, IImplementAFeature implementFeature)
    {
        this.request_criteria = request_criteria;
        this.implement_Feature = implementFeature;
    }

      public void process(IProvideDetailsToCommands request)
    {
      implement_Feature.process(request);
    }

    public bool can_process(IProvideDetailsToCommands request)
    {
      return request_criteria(request);
    }
  }
}