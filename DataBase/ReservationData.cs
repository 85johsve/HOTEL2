using Dapper;
using MySqlConnector;

class ReservationData : Database
{
    Database reservatindb = new Database();
    MySqlConnection connection;

    public ReservationData()
    {
        connection = new MySqlConnection(("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"));
    }
}