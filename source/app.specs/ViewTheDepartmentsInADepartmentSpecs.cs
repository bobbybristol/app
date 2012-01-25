using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewTheDepartmentsInADepartment))]
  public class ViewTheDepartmentsInADepartmentSpecs
  {
    public abstract class concern : Observes<IImplementAFeature,
                                      ViewTheDepartmentsInADepartment>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        store_directory = depends.on<IProvideInformationAboutTheStore>();
        display_engine = depends.on<IDisplayInformation>();
        parent_department = new DepartmentItem();
        the_child_departments = new List<DepartmentItem> {new DepartmentItem()};
        request = fake.an<IProvideDetailsToCommands>();

        request.setup(x => x.map<DepartmentItem>()).Return(parent_department);

        store_directory.setup(x => x.get_the_departments_in(parent_department)).Return(
          the_child_departments);
      };

      Because b = () =>
        sut.process(request);

      It should_get_a_list_of_departments_that_are_children_of_the_selected_department = () =>
        store_directory.received(x => x.get_the_departments_in(parent_department));

      It should_display_the_sub_departments = () =>
        display_engine.received(x => x.display(the_child_departments));
        

      static DepartmentItem parent_department;
      static IProvideDetailsToCommands request;
      static IProvideInformationAboutTheStore store_directory;
      static IDisplayInformation display_engine;
      static IEnumerable<DepartmentItem> the_child_departments;
    }
  }
}