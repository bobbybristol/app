 using System.Collections.Generic;
 using System.Linq;
 using Machine.Specifications;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(CommandRegistry))]  
  public class CommandRegistrySpecs
  {
    public abstract class concern : Observes<IFindCommands,
                                      CommandRegistry>
    {
        
    }

   
    public class when_finding_a_command : concern
    {

      public class and_it_has_the_command_for_the_request
      {
        Establish c = () =>
        {
          request = fake.an<IProvideDetailsToCommands>();
          the_command_that_can_process_the_request = fake.an<IProcessOneRequest>();
          all_the_commands = Enumerable.Range(1, 100).Select(x => fake.an<IProcessOneRequest>()).ToList();
          all_the_commands.Add(the_command_that_can_process_the_request);

          the_command_that_can_process_the_request.setup(x => x.can_process(request)).Return(true);

          depends.on<IEnumerable<IProcessOneRequest>>(all_the_commands);
        };

        Because b = () =>
          result = sut.get_the_command_that_can_process(request);

        It should_return_the_command_to_the_caller = () =>
          result.ShouldEqual(the_command_that_can_process_the_request);


        static IProcessOneRequest result;
        static IProcessOneRequest the_command_that_can_process_the_request;
        static IProvideDetailsToCommands request;
        static List<IProcessOneRequest> all_the_commands;
      }
        
    }
  }
}
