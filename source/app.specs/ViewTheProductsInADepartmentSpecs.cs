using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
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

        Establish c = () =>
      {
        store_directory = depends.on<IProvideInformationAboutTheStore>();
        display_engine = depends.on<IDisplayInformation>();
        parent_department = new DepartmentItem();
        the_products_list = new List<ProductItem> {new ProductItem()};
        request = fake.an<IProvideDetailsToCommands>();

        request.setup(x => x.map<DepartmentItem>()).Return(parent_department);

        store_directory.setup(x => x.get_the_products_in_a_department(parent_department)).Return(
          the_products_list);
      };

      Because b = () =>
        sut.process(request);

    //  It should_get_a_list_of_departments_that_are_children_of_the_selected_department = () =>
      //  store_directory.received(x => x.get_the_departments_in(parent_department));

      It shshould_display_the_products_in_the_departmentould_display_the_sub_departments = () =>
        display_engine.received(x => x.display(the_products_list));
        

      static DepartmentItem parent_department;
      static IProvideDetailsToCommands request;
      static IProvideInformationAboutTheStore store_directory;
      static IDisplayInformation display_engine;
      static IEnumerable<ProductItem> the_products_list;


     
    }
  }
}