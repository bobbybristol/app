 using Machine.Specifications;
 using app.web.application.catalogbrowsing;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

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
        request = fake.an<IProvideDetailsToCommands>();
      };

      Because b = () =>
        sut.process(request);

      It should_get_a_list_of_all_the_main_departments = () =>
        store_directory.received(x => x.get_the_main_departments());


      static IProvideDetailsToCommands request;
      static IProvideInformationAboutTheStore store_directory;
    }
  }
}
