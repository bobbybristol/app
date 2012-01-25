using System.Data;

namespace app
{
  public class Calculator
  {
    IDbConnection connection;

    public Calculator(IDbConnection connection)
    {
      this.connection = connection;
    }

    public int add(int first, int second)
    {
      connection.Open();
      connection.CreateCommand().ExecuteNonQuery();
        
      return first + second;
    }
  }
}