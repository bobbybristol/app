using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Calculator))]
  public class CalculatorSpecs
  {
    public abstract class concern : Observes<Calculator>
    {
    }

    public class when_adding_two_numbers : concern
    {
      Because b = () =>
        result = Calculator.add(2, 3);

      It should_return_the_sum = () =>
        result.ShouldEqual(5);

      static int result;
    }
  }
}