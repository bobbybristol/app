using System.Collections.Generic;

namespace app.web.application.catalogbrowsing
{
  public interface IProvideInformationAboutTheStore
  {
    IEnumerable<DepartmentItem> get_the_main_departments();
  }
}