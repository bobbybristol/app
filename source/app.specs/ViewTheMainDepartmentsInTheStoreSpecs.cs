using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewTheMainDepartmentsInTheStore))]
  public class ViewTheMainDepartmentsInTheStoreSpecs
  {
    public abstract class concern : Observes<IImplementAFeature,
                                      ViewTheMainDepartmentsInTheStore>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        store_directory = depends.on<IProvideInformationAboutTheStore>();
        display_engine = depends.on<IDisplayInformation>();
        the_main_departments = new List<DepartmentItem> {new DepartmentItem()};
        request = fake.an<IProvideDetailsToCommands>();

        store_directory.setup(x => x.get_the_main_departments()).Return(the_main_departments);
      };

      Because b = () =>
        sut.process(request);

      It should_display_the_main_departments = () =>
        display_engine.received(x => x.display(the_main_departments));

      static IProvideDetailsToCommands request;
      static IProvideInformationAboutTheStore store_directory;
      static IDisplayInformation display_engine;
      static IEnumerable<DepartmentItem> the_main_departments;
    }
  }
}