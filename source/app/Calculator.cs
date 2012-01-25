using System.Data;

namespace app
{
  public class Calculator
  {
      private IDbConnection connection;
    public Calculator(IDbConnection connection)
    {
        this.connection = connection;
    }

    public int add(int first, int second)
    {
        connection.Open();
        return first + second;
    }
  }
}