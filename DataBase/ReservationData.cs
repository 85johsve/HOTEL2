using Dapper;
using MySqlConnector;

class ReservationData 
{
    
    MySqlConnection connection;

    public ReservationData()
    {
        connection = new MySqlConnection(("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"));
    }
}