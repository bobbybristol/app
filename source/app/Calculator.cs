using System.Data;

namespace app
{
  public class Calculator
  {
    public Calculator(IDbConnection connection)
    {
    }

    public int add(int first, int second)
    {
      return first + second;
    }
  }
}