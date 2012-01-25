 using Machine.Specifications;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(RequestCommand))]  
  public class RequestCommandSpecs
  {
    public abstract class concern : Observes<IProcessOneRequest,
                                      RequestCommand>
    {
        
    }

   
    public class when_determining_if_it_can_process_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsToCommands>();
          request.received( x => x.request_type );
      };

      Because b = () =>
        result = sut.can_process(request);

        It should_check_the_request_type = () =>
                                           request.request_type

      static IProvideDetailsToCommands request;
      static bool result;
    }
  }
}
