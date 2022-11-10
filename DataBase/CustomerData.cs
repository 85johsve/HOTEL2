using Dapper;
using MySqlConnector;
class CustomerData : Database
{
    Database customerdb = new Database();
    MySqlConnection connection;


    public CustomerData()
    {
        connection = new MySqlConnection(("Server=localhost;Database=hotelmg;Uid=Tina;Pwd=123456;"));

    }
}