using System.Data;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(Calculator))]
  public class CalculatorSpecs
  {

    public abstract class concern : Observes<Calculator>
    {
      
    }

    public class when_created :concern
    {
      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();
      };

      It should_not_open_the_connection = () =>
        connection.never_received(x => x.Open());

      static IDbConnection connection;
    }
    public class when_adding_two_positive_numbers :concern
    {
      //Arrange
      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();
      };

      //Act
      Because b = () =>
        result = sut.add(2, 3);

      //Assert
      It should_return_the_sum = () =>
        result.ShouldEqual(5);

      It should_open_a_connection_to_the_database = () =>
        connection.received(x => x.Open());
        

      static int result;
      static IDbConnection connection;
    }
  }
}