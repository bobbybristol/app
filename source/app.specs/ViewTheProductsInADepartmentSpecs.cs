using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewTheProductsInADepartment))]
  public class ViewTheProductsInADepartmentSpecs
  {
    public abstract class concern : Observes<IImplementAFeature,
                                      ViewTheProductsInADepartment>
    {
    }

    public class when_run : concern
    {
      It should_display_the_products_in_the_department = () => 
    }
  }
}