using System.Web;

namespace app.web.core.stubs
{
  public class StubDisplayEngine:IDisplayInformation
  {
    public void display<ReportModel>(ReportModel model)
    {
      HttpContext.Current.Items["blah"] = model;
      HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx",true);
    }
  }
}