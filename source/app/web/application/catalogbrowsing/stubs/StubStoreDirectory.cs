using System.Collections.Generic;
using System.Linq;

namespace app.web.application.catalogbrowsing.stubs
{
  public class StubStoreDirectory : IProvideInformationAboutTheStore
  {
    public IEnumerable<DepartmentItem> get_the_main_departments()
    {
      return Enumerable.Range(1, 100).Select(x => new DepartmentItem{name = x.ToString("Department 0")});
    }

      public IEnumerable<DepartmentItem> get_the_departments_in(DepartmentItem parent)
      {
          return Enumerable.Range(1, 100).Select(x => new DepartmentItem { name = x.ToString("Sub Department 0") });
      }
  }
}