 using System.Collections.Generic;
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
          info_viewer = depends.on<IDisplayInformation>();
        request = fake.an<IProvideDetailsToCommands>();
      };

      Because b = () =>
        sut.process(request);

      It should_get_a_list_of_all_the_main_departments = () =>
        store_directory.received(x => x.get_the_main_departments());

        It should_display_the_list = () =>
                                     info_viewer.received( x => x.show_list( ) );



      static IProvideDetailsToCommands request;
      static IProvideInformationAboutTheStore store_directory;
        static IDisplayInformation info_viewer;

    }
  }

    
}
