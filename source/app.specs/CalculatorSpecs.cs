using System;
using System.Data;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Calculator))]
  public class CalculatorSpecs
  {
    public abstract class concern : Observes<Calculator>
    {
    }

    public class when_created : concern
    {
      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();
      };

      It should_not_open_the_connection = () =>
        connection.never_received(x => x.Open());

      static IDbConnection connection;
    }

    public class when_adding : concern
    {
      public class two_positive_numbers
      {
        Establish c = () =>
        {
          connection = depends.on<IDbConnection>();
          command = fake.an<IDbCommand>();

          connection.setup(x => x.CreateCommand()).Return(command);
        };

        Because b = () =>
          result = sut.add(2, 3);

        It should_return_the_sum = () =>
          result.ShouldEqual(5);

        It should_open_a_connection_to_the_database = () =>
          connection.received(x => x.Open());

        It should_run_a_command = () =>
          command.received(x => x.ExecuteNonQuery());

        It should_dispose_its_resources = () =>
        {
          connection.received(x => x.Dispose());
          command.received(x => x.Dispose());
        };

        static int result;
        static IDbConnection connection;
        static IDbCommand command;
      }

      public class a_negative_number_to_a_positive
      {
        Because b = () =>
          spec.catch_exception(() => sut.add(2, -3));

        It should_throw_an_argument_exception = () =>
          spec.exception_thrown.ShouldBeAn<ArgumentException>();
      }
    }
  }
}