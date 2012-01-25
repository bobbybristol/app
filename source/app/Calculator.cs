using System;
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
        if (first < 0 || second < 0)
            throw new System.ArgumentException();


      using (connection)
      using (var command = connection.CreateCommand())
      {
        connection.Open();
        command.ExecuteNonQuery();
      }

      return first + second;
    }
  }
}