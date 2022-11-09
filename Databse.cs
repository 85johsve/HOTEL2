using Dapper;
using MySqlConnector;
class Database
{
      MySqlConnection connection;



    public Database()
    {
        connection = new MySqlConnection(("Server=localhost;Database=Hotelmg;Uid=Tina;Pwd=123456;"));
        
    }

    // public Database()
    // {
    //     connection = new MySqlConnection(("Server=localhost;Database=Hotelmg;Uid=Tina;Pwd=123456;"));
    // }



    
}