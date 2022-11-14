using Dapper;
using MySqlConnector;
using System.Data;

class ReservationData 
{
    
    MySqlConnection connection;

    public ReservationData()
    {
        connection = new MySqlConnection(("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"));
    }
      public void Open()
    {
        if(connection.State != ConnectionState.Open)
            connection.Open();
    }
}